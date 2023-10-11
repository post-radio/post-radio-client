using Cysharp.Threading.Tasks;

namespace Global.Network.Session.Runtime.Create
{
    public interface ISessionCreate
    {
        UniTask<SessionCreateResult> Create(string id);
    }
}