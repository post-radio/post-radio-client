namespace Global.Inputs.View.Runtime.Sources
{
    public interface IInputSourcesHandler
    {
        void AddListener(IInputSource source);
        
        void InvokeListen();
        void Dispose();
    }
}