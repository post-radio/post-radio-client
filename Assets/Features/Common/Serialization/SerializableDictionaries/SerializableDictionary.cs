using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Serialization.SerializableDictionaries
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>,ISerializationCallbackReceiver
    {
        [SerializeField] private TKey[] _keys;

        [SerializeField] private TValue[] _values;

        public void OnAfterDeserialize()
        {
            Clear();
            
            for (var i = 0; i < _keys.Length && i < _values.Length; i++)
                this[_keys[i]] = _values[i];
        }

        public void OnBeforeSerialize()
        {
            var count = this.Count;

            _keys = new TKey[count];
            _values = new TValue[count];

            var i = 0;

            foreach (var item in this)
            {
                _keys[i] = item.Key;
                _values[i] = item.Value;

                i++;
            }
        }
    }
}