using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldComponent : MonoBehaviour
{
    [SerializeField] private Cooldown _cooldown;
    [SerializeField] private HealthComponent _health;

    public void Use()
    {
        _health.Immune.Retain(this);
        _cooldown.Reset();
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_cooldown.IsReady)
            gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _health.Immune.Release(this);
    }
}
