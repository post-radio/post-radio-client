using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Network.Room.Entities.Factory
{
    public interface ISceneEntityFactory
    {
        RagonEntity CreateLocal();
        UniTask AttachAsync(RagonEntity entity);
        UniTask<RagonEntity> Create();
        UniTask<RagonEntity> Create(params RagonProperty[] properties);
    }
}