﻿using Common.Serialization.NestedScriptableObjects.Attributes;
using Global.Localizations.Texts;
using Global.Publisher.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Abstract.Purchases
{
    [CreateAssetMenu(fileName = PublisherRoutes.ProductName,
        menuName = PublisherRoutes.ProductPath)]
    public class ProductLink : ScriptableObject, IProductLink
    {
        [SerializeField] private PaymentMethod _paymentMethod;
        [SerializeField] private string _id;
        [SerializeField] private Sprite _shopIcon;
        [ShowIf("_paymentMethod", PaymentMethod.Currency)]
        [SerializeField] private int _price;
        
        [SerializeField] [NestedScriptableObjectField] private LanguageTextData _description;

        public Sprite ShopIcon => _shopIcon;
        public LanguageTextData Description => _description;
        public string Id => _id;
        public int Price => _price;
        public PaymentMethod PaymentMethod => _paymentMethod;

        public void UpdatePrice(int price)
        {
            _price = price;
        }
    }
}