// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-06 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using UnityEngine;

public class SingletonPatternExample3 : MonoBehaviour
{
    void Start()
    {
        Manager.Instance.AudioManager.PlaySound();
        Manager.Instance.UIManager.OpenUI();
    }
}

public sealed class Manager
{
    private static readonly Manager _instance = new();
    private readonly AudioManager _audioManager;
    private readonly UIManager _uiManager;
    public AudioManager AudioManager
    {
        get { return _audioManager; }
    }
    public UIManager UIManager
    {
        get { return _uiManager; }
    }
    private Manager()
    {
        _audioManager = new AudioManager();
        _uiManager = new UIManager();
    }
    public static Manager Instance
    {
        get { return _instance; }
    }
}

public class AudioManager
{
    public void PlaySound()
    {
        Debug.Log("AudioManager PlaySound");
    }
}

public class UIManager
{
    public void OpenUI()
    {
        Debug.Log("UIManager OpenUI");
    }
}