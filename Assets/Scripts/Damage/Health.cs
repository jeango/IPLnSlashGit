using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Values")]
    [SerializeField]
    int initHealth;
    [SerializeField]
    int maxHealth;

    [Header("Events")]
    public UnityEvent onDeath;

    int currenthealth;

    private void OnEnable()
    {
        currenthealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
            onDeath.Invoke();
    }
}
