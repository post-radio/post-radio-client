using Menu.Common.Paths;

namespace Menu.StateMachine.Common
{
    public class StateMachineRoutes
    {
        public const string ServiceName = MenuAssetsPrefixes.Service + "StateMachine";
        public const string ServicePath = MenuAssetsPaths.Root + "StateMachine/Service";
        
        public const string TadDefinitionName = "TadDefinition_";
        public const string TadDefinitionPath = MenuAssetsPaths.Root + "StateMachine/TadDefinition";
        
        public const string ConfigName = "Config_TabsTransition";
        public const string ConfigPath = MenuAssetsPaths.Root + "StateMachine/Config";
    }
}