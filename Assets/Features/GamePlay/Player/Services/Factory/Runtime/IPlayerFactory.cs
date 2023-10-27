using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Definition;

namespace GamePlay.Player.Factory.Runtime
{
    public interface IPlayerFactory
    {
        UniTask<INetworkPlayer> CreateLocal();
    }
}