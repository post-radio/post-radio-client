using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Ragon.Client;
using UnityEngine;
using NetworkPlayer = GamePlay.Player.Services.Entity.NetworkPlayer;

namespace GamePlay.Player.Services.Lists.Runtime
{
    public class PlayersList : IPlayersList, IRagonPlayerLeftListener, INetworkSceneEntityCreationListener
    {
        private readonly Dictionary<RagonPlayer, NetworkPlayer> _players = new();
        private RagonEntity _entity;
        
        public NetworkPlayer Owner { get; }
        public IReadOnlyList<NetworkPlayer> All { get; }

        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            _entity = await factory.Create();
        }
        
        public void Add(RagonPlayer player, NetworkPlayer data)
        {
            _players.Add(player, data);
        }

        public NetworkPlayer Get(RagonPlayer player)
        {
            if (_players.ContainsKey(player) == false)
            {
                Debug.LogError($"Player: {player.Name} not found in registry");
                return null;
            }
            
            return _players[player];
        }

        public void OnPlayerLeft(RagonClient client, RagonPlayer player)
        {
            if (_players.ContainsKey(player) == false)
            {
                Debug.LogError($"Player: {player.Name} not found in registry");
                return;
            }

            _players.Remove(player);
        }
    }
}