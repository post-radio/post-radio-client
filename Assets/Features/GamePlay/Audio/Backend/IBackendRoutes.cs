namespace GamePlay.Audio.Backend
{
    public interface IBackendRoutes
    {
        string AudioStorage(string audioLink);
        string GetAudioLink();
        string LinkValidation();
        string Playlist();
    }
}