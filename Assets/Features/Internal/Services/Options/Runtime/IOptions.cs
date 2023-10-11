namespace Internal.Services.Options.Runtime
{
    public interface IOptions
    {
        void Setup();
        
        T GetOptions<T>() where T : OptionsEntry;
    }
}