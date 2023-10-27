﻿using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using GamePlay.Player.Common.Paths;
using GamePlay.Player.Factory.Runtime;
using GamePlay.Player.Lists.Runtime;
using GamePlay.Player.Relocation.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "PlayerServicesCompose", menuName = PlayerAssetsPaths.Root + "Compose")]
    public class PlayerServicesCompose : ScriptableObject
    {
        [SerializeField] private PlayerFactoryServiceFactory _factory;
        [SerializeField] private PlayersListFactory _list;
        [SerializeField] private RelocationFactory _relocation;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _factory,
            _list,
            _relocation
        };
    }
}