using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : AnimatedWindow
{

    private Action _closeAction;

    public void OnShowSettings()
    {
        var window = Resources.Load<GameObject>("UI/SettingsWindow");
        var canvas = GameObject.Find("CanvasMAIN");
        Instantiate(window, canvas.transform);


    }

    public void OnStartGame()
    {
        _closeAction = () => 
        {
           var loader = FindObjectOfType<LevelLoader>();
           loader.LoadLevel("FirstLvl");
        };
        Close();
    }

    public void OnLanguage()
    {
        var window = Resources.Load<GameObject>("UI/LocalizationWindow");
        var canvas = GameObject.Find("CanvasMAIN");
        Instantiate(window, canvas.transform);

    }

    public void OnExit()
    {
        _closeAction = () => 
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

#endif 
        };
        Close();
        }

    public override void OnCloseAnimationCopmplete()
    {
        base.OnCloseAnimationCopmplete();
        _closeAction?.Invoke();


    }


}
