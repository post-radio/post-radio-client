using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace Global.Network.Objects.Factories.Abstract
{
    public interface IEntityFactory
    {
        ushort Id { get; }

        UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity);
        void AssignId(ushort id);
    }
}