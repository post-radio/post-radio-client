using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Purchases;
using Global.Publisher.Yandex.Common;
using Global.System.MessageBrokers.Runtime;

namespace Global.Publisher.Yandex.Advertisement
{
    public class Ads : IAds, IScopeEnableAsyncListener
    {
        private Ads(
            YandexCallbacks callbacks,
            IDataStorage dataStorage,
         //   IPause pause,
            IAdsAPI api,
            IProductLink adsProduct)
        {
            _callbacks = callbacks;
            _dataStorage = dataStorage;
        //    _pause = pause;
            _api = api;
            _adsProduct = adsProduct;
        }

        private readonly IAdsAPI _api;
        private readonly IProductLink _adsProduct;
        private readonly IDataStorage _dataStorage;
        private readonly YandexCallbacks _callbacks;

      //  private readonly IPause _pause;
        
        private AdsSave _save;

        public async UniTask OnEnabledAsync()
        {
            _save = await _dataStorage.GetEntry<AdsSave>(AdsSave.Key);
            
            Msg.Listen<PurchaseEvent>(OnProductUnlocked);
        }
        
        public void ShowInterstitial()
        {
            ProcessInterstitial().Forget();
        }

        public async UniTask<RewardAdResult> ShowRewarded()
        {
            //_pause.Pause();

            var handler = new RewardedHandler(_callbacks, _api);
            var result = await handler.Show();

         //   _pause.Continue();

            return result;
        }

        private async UniTaskVoid ProcessInterstitial()
        {
            if (_save.IsDisabled == true)
                return;
            
            //_pause.Pause();

            var handler = new InterstitialHandler(_callbacks, _api);
            await handler.Show();

           // _pause.Continue();
        }
        
        private void OnProductUnlocked(PurchaseEvent purchase)
        {
            if (purchase.ProductLink != _adsProduct)
                return;
            
            _save.OnDisabled();
        }
    }
}