using System;
using UnityEngine;

namespace SecondDinner.Common
{
    /// <summary>
    /// Singleton for MonoBehaviours
    /// </summary>
    /// <typeparam name="TMonoBehaviourSingleton">The type of MonoBehaviour to Singleton</typeparam>
    [Serializable]
    public abstract class MonoBehaviourSingleton<TMonoBehaviourSingleton> : MonoBehaviour
        where TMonoBehaviourSingleton : MonoBehaviourSingleton<TMonoBehaviourSingleton>
    {
        private static TMonoBehaviourSingleton instance;

        /// <summary>
        /// The instance of the MonoBehaviour Singleton
        /// </summary>
        protected static TMonoBehaviourSingleton Instance
        {
            get
            {
                if (!instance)
                {
                    instance = FindObjectOfType<TMonoBehaviourSingleton>();
                }
                return instance;
            }
        }
    }
}