using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Chat.Common;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Chat.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ChatRoutes.UIName, menuName = ChatRoutes.UIPath)]
    public class ChatUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var scene = await utils.SceneLoader.LoadTyped<ChatUI>(_scene);
            services.RegisterInstance(scene.Searched)
                .AsCallbackListener();
        }
    }
}