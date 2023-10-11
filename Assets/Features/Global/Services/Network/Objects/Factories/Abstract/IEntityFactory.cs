using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace Global.Network.Objects.Factories.Abstract
{
    public interface IEntityFactory
    {
        int Id { get; }

        UniTaskVoid CreateRemote(int objectId, RagonEntity entity);
        void AssignId(int id);
    }
}