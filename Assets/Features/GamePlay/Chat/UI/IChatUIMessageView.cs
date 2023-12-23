using GamePlay.Player.Entity.Definition;

namespace GamePlay.Chat.UI
{
    public interface IChatUIMessageView
    {
        void Construct(INetworkPlayer player, string message);
        float GetHeight();
        void Destroy();
    }
}