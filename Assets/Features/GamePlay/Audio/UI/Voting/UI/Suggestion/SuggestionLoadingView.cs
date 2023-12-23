using Nova;
using UnityEngine;

namespace GamePlay.Audio.UI.Voting.UI.Suggestion
{
    [DisallowMultipleComponent]
    public class SuggestionLoadingView : MonoBehaviour
    {
        [SerializeField] private UIBlock2D _image;
        [SerializeField] private float _rotateSpeed = 10f;

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            var progress = _image.RadialFill.FillAngle;
            _image.RadialFill.FillAngle = progress + Time.deltaTime * _rotateSpeed;

            if (_image.RadialFill.FillAngle >= 360f)
                _image.RadialFill.FillAngle = 0f;
        }
    }
}