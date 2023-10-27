using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.House.Cells.Factory;
using GamePlay.House.Common.Paths;
using GamePlay.House.Root;
using GamePlay.House.Setup;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.House.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HouseRoutes.HouseSetupName, menuName = HouseRoutes.HouseSetupPath)]
    public class HouseServicesFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private CellFactoryConfig _cellFactoryConfig;
        [SerializeField] private HouseSetupConfig _houseSetupConfig;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<CellFactory>()
                .WithParameter(_cellFactoryConfig)
                .As<ICellFactory>();

            services.Register<HouseSetup>()
                .WithParameter(_houseSetupConfig)
                .As<IHouseSetup>();

            services.Register<HouseCells>()
                .As<IHouseCells>();
        }
    }
}