using Common.UI.Buttons.Events;
using Common.UI.Definitions;
using MPUIKIT;
using UnityEngine;

namespace Common.UI.Buttons
{
    public class ColorSwitchButtonState : ButtonState,
        IPointerEnterListener,
        IPointerExitListener,
        IPointerDownListener,
        IPointerUpListener,
        IButtonUpdatable
    {
        [SerializeField] private UIColor _idle;
        [SerializeField] private UIColor _selected;
        [SerializeField] private UIColor _pressed;
        [SerializeField] private UITransitionTime _time;
        [SerializeField] private MPImage _image;

        private Color _targetColor;
        private Color _startColor;
        private float _currentTime;
        
        private ITriggerReceiver _utilsTriggerReceiver;

        public override void Construct(IButtonUtils utils)
        {
            _utilsTriggerReceiver = utils.TriggerReceiver;
            
            _utilsTriggerReceiver.PointerEnter += OnPointerEnter;
            _utilsTriggerReceiver.PointerExit += OnPointerExit;
            _utilsTriggerReceiver.PointerDown += OnPointerDown;
            _utilsTriggerReceiver.PointerUp += OnPointerUp;

            _image.color = _idle.Value;
            _targetColor = _idle.Value;
            _currentTime = 1f;
        }

        public override void Dispose()
        {
            
        }
        
        public void UpdateState(float delta)
        {
            _currentTime += delta;
            var progress = _currentTime / _time.Value;
            
            if (progress > 1f)
                return;
            
            _image.color = Color.Lerp(_startColor, _targetColor, progress);
        }

        public void OnPointerEnter()
        {
            _currentTime = 0f;
            _startColor = _image.color;
            _targetColor = _selected.Value;
        }

        public void OnPointerExit()
        {
            _currentTime = 0f;
            _startColor = _image.color;
            _targetColor = _idle.Value;
        }

        public void OnPointerDown()
        {
            _currentTime = 0f;
            _startColor = _image.color;
            _targetColor = _pressed.Value;
        }

        public void OnPointerUp()
        {
            _currentTime = 0f;
            _startColor = _image.color;
            _targetColor = _idle.Value;
        }
    }
}