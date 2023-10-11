namespace Internal.Services.Scenes.Abstract
{
    public interface ISceneLoadTypedResult<T> : ISceneLoadResult
    {
        T Searched { get; }
    }
}