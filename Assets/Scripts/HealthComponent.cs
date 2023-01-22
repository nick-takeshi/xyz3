using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] public UnityEvent _onDamage;
    [SerializeField] public UnityEvent _onDie;
    [SerializeField] private UnityEvent _onHealing;
    [SerializeField] public HealthChangeEvent _onChange;
    private Lock _immune = new Lock();


    private GameSession _session;


    public int Health => _health;
    public Lock Immune => _immune;
    

    public void Start()
    {
       _session = FindObjectOfType<GameSession>();
    }
    public void ApplyDamage(int damageValue)
    {
        if (Immune.IsLocked) return;
        if (_health <= 0) return;
        

        
        _health -= damageValue;

        _onDamage?.Invoke();

        _onChange?.Invoke(_health);

        if (_health <= 0)
        {
            _onDie?.Invoke();
        }

        
    }
    public void HealHP(int healValue)
    {
        _health += healValue;

    }

    public void SetHealth(int health)
    {
        _health = health;
    }

    private void OnDestroy()
    {
        _onDie.RemoveAllListeners();
    }

    [Serializable]
    public class HealthChangeEvent : UnityEvent<int>
    {

    }
}
