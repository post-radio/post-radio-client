using TMPro;
using UnityEngine;

namespace Menu.Settings.UI
{
    [DisallowMultipleComponent]
    public class DropDownArrowRotator : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] [Min(0f)] private float _rotationSpeed;

        private const float _startAngle = 0f;
        private const float _targetAngle = 90f;
        
        private float _progress;
        
        private void Update()
        {
            var delta = Time.deltaTime * _rotationSpeed;
            
            if (_dropdown.IsExpanded == true)
                _progress += delta;
            else
                _progress -= delta;

            _progress = Mathf.Clamp01(_progress);

            var angle = Mathf.Lerp(_startAngle, _targetAngle, _progress);
            var rotation = Quaternion.Euler(0f, 0f, angle);
            transform.localRotation = rotation;
        }
    }
}