namespace Internal.Services.Scenes.Data
{
    public interface ISceneAsset
    {
        public string Name { get; }
        public SceneAssetReference Reference { get; }
    }
}