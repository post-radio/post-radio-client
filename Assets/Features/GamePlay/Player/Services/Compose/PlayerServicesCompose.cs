using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Player.Common.Paths;
using GamePlay.Player.Services.Factory.Runtime;
using GamePlay.Player.Services.Lists.Runtime;
using GamePlay.Player.Services.Relocation.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "PlayerServicesCompose", menuName = PlayerAssetsPaths.Root + "Compose")]
    public class PlayerServicesCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private PlayerFactoryServiceFactory _factory;
        [SerializeField] private PlayersListFactory _list;
        [SerializeField] private RelocationFactory _relocation;

        public IReadOnlyList<IServiceFactory> Factories =>new IServiceFactory[]
        {
            _factory,
            _list,
            _relocation
        };
    }
}