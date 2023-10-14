using System;
using Internal.Services.Options.Runtime;
using Ragon.Client.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Connection.Configuration
{
    [InlineEditor]
    public class RagonConnectionOptions : OptionsEntry, IRagonConnectionOptions
    {
        [SerializeField] private RagonConnectionType _type;
        
        [SerializeField] [ShowIf("_type", RagonConnectionType.UDP)] 
        private string _ip;
        [SerializeField] [ShowIf("_type", RagonConnectionType.UDP)] 
        private string _udpProtocol;
        [SerializeField] [ShowIf("_type", RagonConnectionType.UDP)] 
        private ushort _port;

        [SerializeField] [ShowIf("_type", RagonConnectionType.WebSocket)] 
        private string _url;
        [SerializeField] [ShowIf("_type", RagonConnectionType.WebSocket)]
        private WebSocketProtocol _webSocketProtocol;

        [SerializeField] [Range(1, 60)] private int _rate;

        public RagonConnectionType Type => _type;
        public string Address => GetAddress();
        public string Protocol => _udpProtocol;
        public ushort Port => _port;
        public int Rate => _rate;

        private string GetAddress()
        {
            switch (_type)
            {
                case RagonConnectionType.None:
                    throw new NullReferenceException();
                case RagonConnectionType.UDP:
                    return _ip;
                case RagonConnectionType.WebSocket:
                    return $"{GetWssProtocol()}://{_url}";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string GetWssProtocol()
        {
            switch (_webSocketProtocol)
            {
                case WebSocketProtocol.WS:
                    return "ws";
                case WebSocketProtocol.WSS:
                    return "wss";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}