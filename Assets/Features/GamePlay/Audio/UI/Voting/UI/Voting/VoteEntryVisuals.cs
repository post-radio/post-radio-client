using System;
using Common.UI.Definitions;
using DG.Tweening;
using GamePlay.Audio.Definitions;
using Global.UI.Nova.Components;
using Nova;
using UnityEngine;

namespace GamePlay.Audio.UI.Voting.UI.Voting
{
    public class VoteEntryVisuals : ItemVisuals
    {
        [SerializeField] [Min(0f)] private float _winnerScale;
        [SerializeField] [Min(0f)] private float _winnerScaleTime;
        
        [SerializeField] private TextBlock _author;
        [SerializeField] private TextBlock _title;
        [SerializeField] private UIBlock2D _image;
        [SerializeField] private UIBlock2D _voteProgress;
        [SerializeField] private UIColor _selectedColor;
        [SerializeField] private Transform _transform;
        [SerializeField] private UIButton _button;
        
        private AudioMetadata _metadata;
        private Color _defaultColor;
        private Action<VoteEntryVisuals, AudioMetadata> _clickCallback;
        
        public AudioMetadata Metadata => _metadata;

        public void Construct(AudioMetadata metadata, Action<VoteEntryVisuals, AudioMetadata> clickCallback)
        {
            _clickCallback = clickCallback;
            _metadata = metadata;
            _author.Text = metadata.Author;
            _title.Text = metadata.Title;
            _transform.localScale = Vector3.one;
            _defaultColor = _image.Color;
            _image.Color = _defaultColor;
            _voteProgress.Size.Percent = Vector3.zero;
            
            _button.Clear();
            _button.Unlock();
            _button.Clicked += OnClick;
        }

        public void Destroy()
        {
            _button.Clicked -= OnClick;
        }

        public void MarkAsWinner()
        {
            _transform.DOScale(Vector3.one * _winnerScale, _winnerScaleTime);
        }

        public void Lock()
        {
            _button.Lock();
        }

        public void ResetSelection()
        {
            _button.Unlock();
            _button.Clear();
        }

        public void UpdateVotePercent(float percent)
        {
            _voteProgress.Size.Percent = new Vector3(percent, 1f, 1f);
        }

        private void OnClick()
        {
            _button.Lock();
            _image.Color = _selectedColor.Value;
            _clickCallback?.Invoke(this, _metadata);
        }
    }
}