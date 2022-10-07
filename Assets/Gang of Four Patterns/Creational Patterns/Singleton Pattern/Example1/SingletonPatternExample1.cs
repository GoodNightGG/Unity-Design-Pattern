// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-06 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using UnityEngine;

namespace SingletonPatternExample1
{
    public class SingletonPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            AudioEngine.Instance.PlayMusic();
            ResourceLoader.Instance.Load();
        }
    }

    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }

    public class AudioEngine : Singleton<AudioEngine>
    {
        public void PlayMusic()
        {
            Debug.Log("AudioEngine PlayMusic!");
        }
    }

    public class ResourceLoader : Singleton<ResourceLoader>
    {
        public void Load()
        {
            Debug.Log("ResourceLoader Load!");
        }
    }
}