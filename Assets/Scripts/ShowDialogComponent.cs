using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowDialogComponent : MonoBehaviour
{
    [SerializeField] private Mode _mode;
    [SerializeField] private DialogData _bound;
    [SerializeField] private DialogDef _external;
    [SerializeField] private UnityEvent _onComplete;

    private DialogueBoxController _dialogBox;
    public void Show()
    {
        _dialogBox = FindDialogController();

        _dialogBox.ShowDialog(Data, _onComplete);
    }
    private DialogueBoxController FindDialogController()
    {
        if (_dialogBox != null) return _dialogBox;

        GameObject controllerGo;

        switch (Data.Type)
        {
            case DialogType.Simple:
                controllerGo = GameObject.FindWithTag("SimpleDialog");
                break;
            case DialogType.Personalized:
                controllerGo = GameObject.FindWithTag("PersonalizedDialog");
                break;
            default:
                throw new ArgumentException("Undefined dialog type");
        }

        return controllerGo.GetComponent<DialogueBoxController>();
    }
    public void Show(DialogDef def)
    {
        _external = def;
        Show();
    }

    public DialogData Data
    {
        get
        {
            switch (_mode)
            {
                case Mode.Bound:
                    return _bound;
                case Mode.External:
                    return _external.Data;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum Mode
    {
        Bound,
        External
    }
}
