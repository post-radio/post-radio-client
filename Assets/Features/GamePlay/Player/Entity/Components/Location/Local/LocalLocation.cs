using System.Threading;
using Common.Architecture.EntityCreators.Runtime.Callbacks;
using Common.Network;
using Cysharp.Threading.Tasks;
using GamePlay.House.Cells.Root;
using GamePlay.Player.Entity.Components.Animators.Runtime;
using GamePlay.Player.Entity.Components.Location.Common;
using GamePlay.Player.Entity.Components.Visual.View;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Location.Local
{
    public class LocalLocation : RagonProperty, IPlayerLocation, IEntityDisableListener
    {
        protected LocalLocation(
            IPlayerAnimator animator,
            IPlayerView view,
            ShowAnimation showAnimation,
            HideAnimation hideAnimation)
            : base(0, false)
        {
            _animator = animator;
            _view = view;
            _showAnimation = showAnimation;
            _hideAnimation = hideAnimation;
        }

        private readonly IPlayerAnimator _animator;
        private readonly IPlayerView _view;
        private readonly ShowAnimation _showAnimation;
        private readonly HideAnimation _hideAnimation;
        private readonly NetworkIntCompressor _compressor = new(0, 1000);

        private CancellationTokenSource _cancellation;

        private ICell _cell;

        public bool HasLocation => Cell != null;
        public ICell Cell => _cell;
        
        public void OnDisabled()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }

        public async UniTask Relocate(ICell cell)
        {
            _cancellation = new CancellationTokenSource();

            if (HasLocation == true)
            {
                await _animator.PlayAsync(_hideAnimation, _cancellation.Token);
                _cell.OnFreed();
            }
            
            _cell = cell;
            MarkAsChanged();

            _view.SnapToCell(_cell);
            _cell.OnTaken();
            await _animator.PlayAsync(_showAnimation, _cancellation.Token);
        }

        public override void Serialize(RagonBuffer buffer)
        {
            if (HasLocation == true)
                _compressor.Write(buffer, _cell.Id);
            else
                _compressor.Write(buffer, -1);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            _compressor.Read(buffer);
        }
    }
}