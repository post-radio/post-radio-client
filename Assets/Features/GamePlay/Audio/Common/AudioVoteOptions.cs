using System;
using UnityEngine;

namespace GamePlay.Audio.Common
{
    [Serializable]
    public class AudioVoteOptions
    {
        [SerializeField] private float _voteStartOffset;
        [SerializeField] private float _voteDuration;
        [SerializeField] private float _voteCollectDuration;
        [SerializeField] private float _voteHideOffset;
        
        public float VoteStartOffset => _voteStartOffset;
        public float VoteDuration => _voteDuration;
        public float VoteCollectDuration => _voteCollectDuration;
        public float VoteHideOffset => _voteHideOffset;
    }
}