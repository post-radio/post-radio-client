using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.GameLoops.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.GameLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GameLoopRouter.MockName,
        menuName = GameLoopRouter.MockPath)]
    public class GameLoopMock : GameLoopFactory
    {
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            
        }
    }
}