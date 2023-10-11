using Cysharp.Threading.Tasks;

namespace Global.Network.Session.Runtime.Leave
{
    public interface ISessionLeave
    {
        UniTask Leave();
    }
}