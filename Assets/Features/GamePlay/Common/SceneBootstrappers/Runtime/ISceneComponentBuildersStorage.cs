namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    public interface ISceneComponentBuildersStorage
    {
        public void SetTargets(SceneComponentRegister[] registers, SceneComponentBuilder[] builders);
    }
}