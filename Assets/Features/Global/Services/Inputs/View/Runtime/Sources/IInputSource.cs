namespace Global.Inputs.View.Runtime.Sources
{
    public interface IInputSource
    {
        void Listen();
        void UnListen();
    }
}