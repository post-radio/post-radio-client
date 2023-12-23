using System;
using System.Collections.Generic;
using Nova;
using UnityEngine;

namespace GamePlay.UI.Tests
{
    [DisallowMultipleComponent]
    public class TestUiView : MonoBehaviour
    {
        public ListView _list;

        public List<SongData> _songs;

        private void Start()
        {
            _list.AddDataBinder<SongData, TestItemView>(BindContact);
            _list.SetDataSource(_songs);
        }
        
        /// <summary>
        /// Binds a Contact to a ContactVisuals
        /// </summary>
        private void BindContact(Data.OnBind<SongData> evt, TestItemView visuals, int index)
        {
            // evt.UserData is the object stored at the given index ^^^ in our data source.
            // In other words, evt.UserData == contacts[index].
            SongData contact = evt.UserData;

            visuals.SongName.Text = contact.SongName;
            visuals.AuthorName.Text = contact.AuthorName;
        }
    }

    [Serializable]
    public class SongData
    {
        public string SongName;
        public string AuthorName;
    }
}