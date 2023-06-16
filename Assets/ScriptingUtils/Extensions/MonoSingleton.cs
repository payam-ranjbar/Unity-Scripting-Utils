using System;
using UnityEngine;

namespace ScriptingUtils
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new GameObject(nameof(T)).AddComponent<T>();
                }

                return _instance;
            }
        }

        public virtual void Awake()
        {
            _instance = this as T;
        }
    }
}