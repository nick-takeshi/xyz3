using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExp : MonoBehaviour
{
    [SerializeField] int _value;
    private GameSession _session;

    public void AddExperience()
    {
        _session = FindObjectOfType<GameSession>();
        _session.Data.Experience.Value += _value;
    }
}
