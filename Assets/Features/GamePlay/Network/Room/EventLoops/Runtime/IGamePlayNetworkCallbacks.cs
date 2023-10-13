using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    public interface IGamePlayNetworkCallbacks : ICallbackRegister
    {
        UniTask InvokeRegisterCallbacks(RagonEventCache events);
        UniTask InvokeSceneEntityCreation();
        UniTask InvokeAwakeCallbacks();
        UniTask InvokeDestroyCallbacks();
    }
}