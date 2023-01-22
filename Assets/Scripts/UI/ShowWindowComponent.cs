using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWindowComponent : MonoBehaviour
{
    [SerializeField] private string _path;

    public void Show()
    {
        var window = Resources.Load<GameObject>(_path);
        var canvas = GameObject.Find("CanvasHUD");
        Instantiate(window, canvas.transform);

    }
}
