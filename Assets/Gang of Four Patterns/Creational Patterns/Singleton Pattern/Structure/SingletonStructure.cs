// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-06 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using UnityEngine;

public class SingletonStructure : MonoBehaviour
{
    void Start()
    {
        Singleton s1 = Singleton.Instance;
        Singleton s2 = Singleton.Instance;

        if (s1 == s2)
            Debug.Log("Objects are same instance");
    }
}

public class Singleton
{
    private static Singleton _instance;

    // Constructor is 'private', if need to be inheritable, set 'private' to 'protected'
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            // not thread-safe.
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

}