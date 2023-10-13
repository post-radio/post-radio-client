using System.Collections.Generic;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public class PlayersList : IPlayersList, IRagonPlayerLeftListener
    {
        private readonly Dictionary<RagonPlayer, NetworkPlayer> _players = new();

        public NetworkPlayer Owner { get; }
        public IReadOnlyList<NetworkPlayer> All { get; }

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