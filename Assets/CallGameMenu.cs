using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGameMenu : MonoBehaviour
{
    public void OnShowGameMenu()
    {
        var window = Resources.Load<GameObject>("UI/GameMenu");
        var canvas = GameObject.Find("CanvasHUD");
        Instantiate(window, canvas.transform);
        Time.timeScale = 0;
    }

    public void OnShowStats()
    {
        //WindowUtils.CreateWindow("UI/PlayerStatsWindow");
        var window = Resources.Load<GameObject>("UI/PlayerStatsWindow");
        var canvas = GameObject.Find("CanvasHUD");
        Instantiate(window, canvas.transform);

    }

    public void OnShowSkins()
    {
        WindowUtils.CreateWindow("UI/ManageSkinsWindow");

    }
}
