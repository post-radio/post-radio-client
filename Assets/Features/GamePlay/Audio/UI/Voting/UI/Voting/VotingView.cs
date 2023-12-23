using System;
using System.Collections.Generic;
using System.Linq;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using Nova;
using UnityEngine;

namespace GamePlay.Audio.UI.Voting.UI.Voting
{
    [DisallowMultipleComponent]
    public class VotingView : MonoBehaviour, IVotingView
    {
        [SerializeField] private ListView _list;
        [SerializeField] private Transform _header;
        
        private readonly Dictionary<string, VoteEntryVisuals> _views = new();

        public event Action<AudioMetadata> Selected;

        private void Awake()
        {
            _list.AddDataBinder<AudioMetadata, VoteEntryVisuals>(BindView);
            _list.AddDataUnbinder<AudioMetadata, VoteEntryVisuals>(UnbindView);
        }

        private void OnEnable()
        {
            _list.Refresh();
        }

        private void OnDestroy()
        {
            _list.RemoveDataBinder<AudioMetadata, VoteEntryVisuals>(BindView);
            _list.RemoveDataUnbinder<AudioMetadata, VoteEntryVisuals>(UnbindView);
        }

        private void BindView(Data.OnBind<AudioMetadata> data, VoteEntryVisuals target, int index)
        {
            var userData = data.UserData;

            if (_views.ContainsKey(userData.Url) == true)
                return;

            target.Construct(data.UserData, OnViewSelected);
            _views.Add(data.UserData.Url, target);
        }

        private void UnbindView(Data.OnUnbind<AudioMetadata> data, VoteEntryVisuals target, int index)
        {
            _views.Remove(data.UserData.Url);
            target.Destroy();
        }

        public void Fill(IReadOnlyDictionary<string, AudioMetadata> entries)
        {
            var entriesList = entries.Values.ToList();
            _views.Clear();
            _list.SetDataSource(entriesList);
            _list.Refresh();
        }

        public void End(AudioMetadata winner)
        {
            foreach (var (_, view) in _views)
                view.Lock();

            if (_views.TryGetValue(winner.Url, out var winnerView) == true)
                winnerView.MarkAsWinner();
            else
                Debug.Log($"No winner for: {winner.Url} found.");
        }

        public void UpdateVotes(IReadOnlyDictionary<string, int> entriesVotes)
        {
            var totalVotes = 0;

            foreach (var (_, votes) in entriesVotes)
                totalVotes += votes;

            foreach (var (url, votes) in entriesVotes)
            {
                var percent = votes / totalVotes;

                if (_views.TryGetValue(url, out var view) == true)
                    view.UpdateVotePercent(percent);
                else
                    Debug.Log($"No winner for: {url} found.");
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnViewSelected(VoteEntryVisuals selectedVisuals, AudioMetadata metadata)
        {
            foreach (var (_, view) in _views)
            {
                if (view == selectedVisuals)
                    continue;

                view.ResetSelection();
            }

            Selected?.Invoke(metadata);
        }

        private void Update()
        {
            _header.SetAsFirstSibling();
        }
    }
}