﻿using System.Collections.Generic;
using Global.Publisher.Yandex.Common;
using UnityEngine;

namespace Global.Publisher.Yandex.DataStorages
{
    public class StorageDebugAPI : IStorageAPI
    {
        public StorageDebugAPI(YandexCallbacks callbacks)
        {
            _callbacks = callbacks;
        }

        private readonly YandexCallbacks _callbacks;

        public void Get_Internal()
        {
            var data = new Dictionary<string, object>();

            var raw = JsonUtility.ToJson(data);
            _callbacks.OnUserDataReceived(raw);
        }

        public void Set_Internal(string data)
        {
        }
    }
}