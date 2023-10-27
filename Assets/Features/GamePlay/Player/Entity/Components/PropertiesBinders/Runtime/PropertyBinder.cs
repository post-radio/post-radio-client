using Ragon.Client;

namespace GamePlay.Player.Entity.Components.PropertiesBinders.Runtime
{
    public class PropertyBinder : IPropertyBinder
    {
        public PropertyBinder(RagonEntity entity)
        {
            _entity = entity;
        }
        
        private readonly RagonEntity _entity;

        public void AddProperty(RagonProperty property)
        {
            _entity.State.AddProperty(property);
        }
    }
}