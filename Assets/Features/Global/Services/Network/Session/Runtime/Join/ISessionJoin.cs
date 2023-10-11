using Cysharp.Threading.Tasks;

namespace Global.Network.Session.Runtime.Join
{
    public interface ISessionJoin
    {
        UniTask<SessionJoinResult> Join(string id);
    }
}