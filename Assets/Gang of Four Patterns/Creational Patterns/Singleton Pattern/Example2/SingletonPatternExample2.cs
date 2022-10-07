// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-06 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using System;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPatternExample2
{
    public class SingletonPatternExample2 : MonoBehaviour
    {
        private void Awake()
        {
            Game gameData = DataCenter.Instance.GetData<Game>();
            Debug.Log("Awake Coin: " + gameData.Coin);
            gameData.Coin = 100;
        }

        void Start()
        {
            Game gameData = DataCenter.Instance.GetData<Game>();
            Global global = DataCenter.Instance.GetData<Global>();

            Debug.Log("Start Coin: " + gameData.Coin);
            Debug.Log("Start serverToken: " + global.ServerToken);
        }
    }

    public sealed class DataCenter
    {
        private static DataCenter _instance = null;
        private readonly Dictionary<Type, object> DataCollections = new Dictionary<Type, object>();
        public static DataCenter Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(DataCenter))
                    {
                        if (_instance == null)
                        {
                            _instance = new DataCenter();
                        }
                    }
                }
                return _instance;
            }
        }

        public T GetData<T>() where T : class
        {
            Type dataType = typeof(T);
            object dataCollection;
            if (!DataCollections.TryGetValue(dataType, out dataCollection))
            {
                dataCollection = CreateDataCollection(dataType);
            }

            return dataCollection as T;
        }

        private object CreateDataCollection(Type dataType)
        {
            object dataCollection = Activator.CreateInstance(dataType);
            DataCollections.Add(dataType, dataCollection);

            return dataCollection;
        }
    }

    public class Global
    {
        private string _serverToken = "sdlfihaiosudefhy9ih3wq";
        public string ServerToken
        {
            get
            {
                return _serverToken;
            }
            set
            {
                _serverToken = value;
            }
        }
    }

    public class Game
    {
        private int _coin = 10;
        public int Coin
        {
            get { return _coin; }
            set
            {
                _coin = value;
            }
        }
    }
}