using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    public int MaxHealth;

    public bool StartWithSpecificHealth;
    [ShowIf(nameof(StartWithSpecificHealth))]
    public int StartingHealth;

    public UnityEvent OnDeath;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = StartWithSpecificHealth ? StartingHealth : MaxHealth;
    }

    public void Damage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
            OnDeath?.Invoke();
    }
}
