using Common.Serialization.ScriptableRegistries;
using Global.Publisher.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Abstract.Purchases
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PublisherRoutes.ProductsRegistryName,
        menuName = PublisherRoutes.ProductsRegistryPath)]
    public class ShopProductsRegistry : ScriptableRegistry<ProductLink>
    {
    }
}