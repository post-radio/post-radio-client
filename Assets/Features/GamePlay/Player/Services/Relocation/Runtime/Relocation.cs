using System;
using System.Collections.Generic;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.House.Cells.Root;
using GamePlay.House.Root;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using GamePlay.Network.Room.EventLoops.Runtime;
using GamePlay.Player.Services.Lists.Events;
using Global.System.MessageBrokers.Runtime;
using Random = UnityEngine.Random;

namespace GamePlay.Player.Relocation.Runtime
{
    public class Relocation : IRelocation, INetworkAwakeListener, IScopeSwitchListener
    {
        public Relocation(
            IMessenger messenger,
            IMessageDistributor messageDistributor,
            IHouseCells cells)
        {
            _messenger = messenger;
            _messageDistributor = messageDistributor;
            _cells = cells;
        }

        private readonly IMessenger _messenger;
        private readonly IMessageDistributor _messageDistributor;
        private readonly IHouseCells _cells;
        
        private readonly List<ICell> _availableCellsList = new();
        private readonly Dictionary<int, ICell> _availableCellsDictionary = new();
        private readonly List<ICell> _takenCells = new();
        private readonly CancellationTokenSource _cancellation = new();

        private IDisposable _playerLeftListener;

        public void OnNetworkAwake()
        {
            _messenger.AddRoute<RelocationRandomRequest, RelocationRandomResponse>(OnRandomRequest);
            _messenger.AddRoute<RelocationTargetRequest, RelocationTargetResponse>(OnTargetRequest);
        }

        public void OnEnabled()
        {
            _availableCellsList.AddRange(_cells.List);

            foreach (var (id, cell) in _cells.Dictionary)
                _availableCellsDictionary.Add(id, cell);

            _playerLeftListener = Msg.Listen<PlayerLeftEvent>(OnPlayerLeft);
        }
        
        public void OnDisabled()
        {
            _playerLeftListener?.Dispose();
            _cancellation.Cancel();
        }

        public ICell GetCell(int id)
        {
            return _cells.Get(id);
        }

        public async UniTask<ICell> GetRandomCell()
        {
            var response = await _messageDistributor.SendOwnerAsync<RelocationRandomRequest, RelocationRandomResponse>(
                new RelocationRandomRequest(), _cancellation.Token);

            return _cells.Get(response.CellId.Value);
        }

        public async UniTask<bool> TryGetTargetCell(ICell target)
        {
            var request = new RelocationTargetRequest(target.Id);
            var response = await _messageDistributor.SendOwnerAsync<RelocationTargetRequest, RelocationTargetResponse>(
                request, _cancellation.Token);

            return response.Result.Value;
        }

        public void OnCellFreed(ICell cell)
        {
            _takenCells.Remove(cell);
            _availableCellsList.Add(cell);
        }

        private async UniTask OnRandomRequest(
            IResponseHandler<RelocationRandomRequest, RelocationRandomResponse> responseHandler)
        {
            var random = Random.Range(0, _availableCellsList.Count);
            var cell = _availableCellsList[random];
            var response = new RelocationRandomResponse(cell.Id);
            _availableCellsDictionary.Remove(cell.Id);
            _availableCellsList.RemoveAt(random);

            responseHandler.Response(response);
        }

        private async UniTask OnTargetRequest(
            IResponseHandler<RelocationTargetRequest, RelocationTargetResponse> responseHandler)
        {
            var targetId = responseHandler.RequestPayload.CellId.Value;
            
            if (_availableCellsDictionary.ContainsKey(targetId) == true)
                responseHandler.Response(new RelocationTargetResponse(true));
            else
                responseHandler.Response(new RelocationTargetResponse(false));
        }
        
        private void OnPlayerLeft(PlayerLeftEvent data)
        {
            var location = data.Player.Root.Location; 
            
            if (location.HasLocation == false)
                return;

            _takenCells.Remove(location.Cell);
            _availableCellsList.Add(location.Cell);
            _availableCellsDictionary.Add(location.Cell.Id, location.Cell);
        }
    }
}