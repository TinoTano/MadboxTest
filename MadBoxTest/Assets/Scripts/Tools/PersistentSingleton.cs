using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            instance = this as T;

            DontDestroyOnLoad(this);
        }
    }
}

