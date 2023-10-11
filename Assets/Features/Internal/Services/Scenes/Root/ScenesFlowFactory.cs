using Internal.Abstract;
using Internal.Services.Options.Implementations;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Addressable;
using Internal.Services.Scenes.Common;
using Internal.Services.Scenes.Logs;
using Internal.Services.Scenes.Native;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Internal.Services.Scenes.Root
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.ServiceName,
        menuName = ScenesFlowRoutes.ServicePath)]
    public class ScenesFlowFactory : ScriptableObject, IInternalServiceFactory
    {
        [SerializeField] [Indent] private ScenesFlowLogSettings _logSettings;

        public void Create(IOptions options, IContainerBuilder builder)
        {
            if (options.GetOptions<AssetsOptions>().UseAddressables == true)
            {
                builder.Register<AddressablesSceneLoader>(Lifetime.Singleton)
                    .As<ISceneLoader>();

                builder.Register<AddressablesScenesUnloader>(Lifetime.Singleton)
                    .As<ISceneUnloader>();
            }
            else
            {
                builder.Register<NativeSceneLoader>(Lifetime.Singleton)
                    .As<ISceneLoader>();

                builder.Register<NativeSceneUnloader>(Lifetime.Singleton)
                    .As<ISceneUnloader>();
            }
            
            builder.Register<ScenesFlowLogger>(Lifetime.Singleton)
                .WithParameter(_logSettings);
        }
    }
}