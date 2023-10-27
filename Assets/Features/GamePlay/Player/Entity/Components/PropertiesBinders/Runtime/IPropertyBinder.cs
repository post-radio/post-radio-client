using Ragon.Client;

namespace GamePlay.Player.Entity.Components.PropertiesBinders.Runtime
{
    public interface IPropertyBinder
    {
        void AddProperty(RagonProperty property);
    }
}