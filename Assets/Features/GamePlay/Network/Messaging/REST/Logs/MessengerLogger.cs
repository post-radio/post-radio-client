using System;
using System.Collections.Generic;
using System.Text;
using GamePlay.Player.Entity.Definition;
using Internal.Services.Loggers.Runtime;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Logs
{
    public class MessengerLogger
    {
        public MessengerLogger(ILogger logger, MessengerLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly MessengerLogSettings _settings;

        public void OnDirectRequestSent<TRequest>(RagonPlayer player)
        {
            if (_settings.IsAvailable(MessengerLogType.Request_Direct_Sent) == false)
                return;

            _logger.Log($"On direct request sent to player: {player.Id} with type: {typeof(TRequest)}",
                _settings.LogParameters);
        }

        public void OnDirectRequestReceived<TRequest>(RagonPlayer player)
        {
            if (_settings.IsAvailable(MessengerLogType.Request_Direct_Received) == false)
                return;

            _logger.Log($"On direct request received on player: {player.Id} with type: {typeof(TRequest)}",
                _settings.LogParameters);
        }

        public void OnDirectResponseSent<TResponse>(RagonPlayer player)
        {
            if (_settings.IsAvailable(MessengerLogType.Response_Direct_Sent) == false)
                return;

            _logger.Log($"On direct response sent to player: {player.Id} with type: {typeof(TResponse)}",
                _settings.LogParameters);
        }

        public void OnDirectResponseReceived<TResponse>(RagonPlayer player)
        {
            if (_settings.IsAvailable(MessengerLogType.Response_Direct_Received) == false)
                return;

            _logger.Log($"On direct response received on player: {player.Id} with type: {typeof(TResponse)}",
                _settings.LogParameters);
        }

        public void NoResponseHandlerFoundException<TResponse>(Guid requestId)
        {
            if (_settings.IsAvailable(MessengerLogType.Response_Direct_Received) == false)
                return;

            _logger.Log($"No response handler of type: {typeof(TResponse)} with id: {requestId}",
                _settings.LogParameters);
        }

        public void OnOwnerRequestSent<TResponse>(NetworkPlayer player)
        {
            if (_settings.IsAvailable(MessengerLogType.Request_Owner_Sent) == false)
                return;

            _logger.Log($"On response sent to owner: {player.Id}/{player.Root.Identity.DisplayName} with type: {typeof(TResponse)}",
                _settings.LogParameters);
        }

        public void OnAllRequestSent<TResponse>(IReadOnlyList<NetworkPlayer> players)
        {
            if (_settings.IsAvailable(MessengerLogType.Request_All_Sent) == false)
                return;

            var stringBuilder = new StringBuilder();

            foreach (var player in players)
                stringBuilder.AppendLine($"{player.Id}/{player.Root.Identity.DisplayName}");

            _logger.Log($"On request sent to all players with type: {typeof(TResponse)} \n Players: \n {stringBuilder}",
                _settings.LogParameters);
        }

        public void OnPipeAdded<TRequest, TResponse>()
        {
            if (_settings.IsAvailable(MessengerLogType.Pipe_Add) == false)
                return;

            _logger.Log($"On pipe of type {typeof(TRequest)}/{typeof(TResponse)} added", _settings.LogParameters);
        }

        public void OnPipeNotFound<T, T1>()
        {
            if (_settings.IsAvailable(MessengerLogType.Pipe_Not_Found_Exception) == false)
                return;

            _logger.Log($"On pipe of type: {typeof(T)} type not matched with: {typeof(T1)}", _settings.LogParameters);
        }
    }
}