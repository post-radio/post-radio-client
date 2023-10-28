﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Global.Publisher.Abstract.Purchases
{
    public interface IPayments
    {
        UniTask<IReadOnlyList<IProductLink>> RestorePurchases();
        UniTask ValidateProducts();
        UniTask<PurchaseResult> TryPurchase(IProductLink productLink);
    }
}