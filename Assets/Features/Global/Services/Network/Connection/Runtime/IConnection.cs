using System;
using Cysharp.Threading.Tasks;

namespace Global.Network.Connection.Runtime
{
    public interface IConnection
    {
        event Action Disconnected;
        
        UniTask<ConnectionResultType> Connect(string playerName);
    }
}