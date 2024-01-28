using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Callbacks;
using GamePlay.Player.Entity.Definition;
using GamePlay.Player.Services.Lists.Events;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.System.MessageBrokers.Runtime;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Player.Services.Lists.Runtime
{
    public class PlayersList :
        IPlayersList,
        IRagonPlayerLeftListener,
        IScopeSwitchListener
    {
        public PlayersList(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        private readonly IClientProvider _clientProvider;

        private readonly Dictionary<RagonPlayer, INetworkPlayer> _dictionary = new();
        private readonly List<INetworkPlayer> _list = new();
        
        private INetworkPlayer _owner;

        public INetworkPlayer Owner => _owner;
        public IReadOnlyList<INetworkPlayer> All => _list;
        
        public void OnEnabled()
        {
            _clientProvider.Client.AddListener(this);
        }

        public void OnDisabled()
        {
            _clientProvider.Client.RemoveListener(this);
        }

        public void Add(INetworkPlayer data)
        {
            _dictionary.Add(data.Player, data);
            _list.Add(data);

            if (data.Player.IsRoomOwner == true)
                _owner = data;
        }

        public INetworkPlayer Get(RagonPlayer player)
        {
            if (_dictionary.ContainsKey(player) == false)
            {
                Debug.LogError($"Player: {player.Name} not found in registry");
                return null;
            }
            
            return _dictionary[player];
        }

        public void OnPlayerLeft(RagonClient client, RagonPlayer player)
        {
            if (_dictionary.ContainsKey(player) == false)
            {
                Debug.LogError($"Player: {player.Name} not found in registry");
                return;
            }

            Msg.Publish(new PlayerLeftEvent(_dictionary[player]));
            _dictionary.Remove(player);
        }
    }
}