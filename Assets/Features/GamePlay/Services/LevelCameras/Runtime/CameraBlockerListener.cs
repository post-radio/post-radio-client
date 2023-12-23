using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Global.System.MessageBrokers.Runtime;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public class CameraBlockerListener : ICameraBlockListener, IScopeSwitchListener
    {
        private int _count;
        
        private IDisposable _blockListener;
        private IDisposable _unblockListener;

        public bool IsBlocked => _count > 0;
        
        public void OnEnabled()
        {
            _blockListener = Msg.Listen<CameraBlockedEvent>(OnBlocked);
            _unblockListener = Msg.Listen<CameraUnblockedEvent>(OnUnblocked);
        }

        public void OnDisabled()
        {
            _blockListener.Dispose();
            _unblockListener.Dispose();
        }

        private void OnBlocked(CameraBlockedEvent payload)
        {
            _count++;
        }
        
        private void OnUnblocked(CameraUnblockedEvent payload)
        {
            _count--;
        }
    }
}