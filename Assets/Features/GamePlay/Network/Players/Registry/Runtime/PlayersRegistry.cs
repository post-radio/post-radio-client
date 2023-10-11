using System.Collections.Generic;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public class PlayersRegistry : IPlayersRegistry, IRagonPlayerLeftListener
    {
        private readonly Dictionary<RagonPlayer, RemotePlayerData> _players = new();

        public void Add(RagonPlayer player, RemotePlayerData data)
        {
            _players.Add(player, data);
        }

        public RemotePlayerData Get(RagonPlayer player)
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