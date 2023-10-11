using Cysharp.Threading.Tasks;

namespace Global.Network.Session.Runtime.Leave
{
    public class SessionLeave : ISessionLeave
    {
        public UniTask Leave()
        {
            return new UniTask();
        }
    }
}