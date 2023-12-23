using System;
using Cysharp.Threading.Tasks;
using Nova;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Networking;

namespace GamePlay.Audio.Test
{
    [DisallowMultipleComponent]
    public class AudioTest : MonoBehaviour
    {
        [SerializeField] private UIBlock2D _image;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private string _musicUri;

        private void Awake()
        {
            LoadAudio().Forget();
        }

        [Button("Audio")]
        private void OnAudioClicked()
        {
        }
        
        private async UniTask<Texture2D> LoadImage()
        {
            var uri = "https://sun9-16.userapi.com/" +
                      "impf/c841636/v841636744/2f01f/" +
                      "PfSIA1HojdU.jpg?size=1600x1200&quality=96&sign=a3035c556c280b3a9b49e979fb0ad6a3&type=album";
            
            using var downloadHandler = new DownloadHandlerTexture(true);
            using var request = new UnityWebRequest(uri, "GET",  downloadHandler, null);
            await request.SendWebRequest().ToUniTask();

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
                return null;
            }

            return downloadHandler.texture;
        }

        private async UniTask LoadAudio()
        {
            var audioType = AudioType.MPEG;
            using var downloadHandlerAudioClip = new DownloadHandlerAudioClip(_musicUri, audioType);
            using var request = new UnityWebRequest(_musicUri, "GET", downloadHandlerAudioClip, null);

            try
            {
                var response = await request.SendWebRequest().ToUniTask();
            }
            catch (Exception e)
            {
                _image.Color = Color.red;
                Debug.Log(e.Message);
            }

            _audio.clip = downloadHandlerAudioClip.audioClip;
            _audio.Play();
        }
    }
}