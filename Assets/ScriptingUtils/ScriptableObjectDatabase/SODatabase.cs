using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptingUtils.ScriptableObjectDatabase
{
    public interface IDBItem<out T>
    {
        T Key { get; }
    }

    public abstract class SOGenericDatabase<KEYTYPE, VALUETYPE> : ScriptableObject where VALUETYPE : IDBItem<KEYTYPE>
    {
        protected abstract bool RuntimeMutable { get; }
        protected abstract bool EditorMutable { get; }
        
        protected abstract List<VALUETYPE> ItemList { get; }
        
        private Dictionary<KEYTYPE, VALUETYPE> _dictionary;

        protected bool initialized;

        protected void BuildDictionary()
        {
            _dictionary = _dictionary.BuildFromList(ItemList, item => item.Key);
            initialized = true;
        }

        public VALUETYPE Get(KEYTYPE key)
        {
            return Has(key) ? _dictionary[key] : default;
        }

        public bool TryGet(KEYTYPE key, out VALUETYPE value)
        {
            var contains = Has(key);

            value = default;
            
            if (contains)
            {
                value = _dictionary[key];
            }

            return contains;
        }

        public bool Add(VALUETYPE value)
        {
            if (!RuntimeMutable) return false;

            var contains = Has(value.Key);
            
            if (contains) return true;


            _dictionary.Add(value.Key, value);

            ItemList.AddIfNotContained(value);

            return true;
        }

        public bool Modify(VALUETYPE value)
        {
            if (!RuntimeMutable) return false;

            var contains = Has(value.Key);
            
            if (!contains) return false;


            _dictionary[value.Key] = value;
            
            var index = ItemList.IndexOf(value);
            ItemList[index] = value;
            

            return true;
        }

        public bool Has(KEYTYPE key)
        {
            return _dictionary.ContainsKey(key);
        }

        private void OnValidate()
        {
            if (!EditorMutable)
            {
                Debug.LogError("Modifying an immutable DB detected");
                return;
            }
            
            BuildDictionary();
        }
    }
}