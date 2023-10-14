using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace Global.Network.Objects.Factories.Abstract
{
    public interface IEntityFactory
    {
        int Id { get; }

        UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity);
        void AssignId(int id);
    }
}