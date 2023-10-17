namespace Menu.Main.UI
{
    public interface IMainInterceptor
    {
        void CreateRequested();
        void RandomRequested();
        void WithIdRequested(string id);
    }
}