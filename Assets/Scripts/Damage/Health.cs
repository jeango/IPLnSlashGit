using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using IPL.EventTypes;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Values")]
    [SerializeField]
    int initHealth;
    [SerializeField]
    int maxHealth;

    [Header("Events")]
    public UnityEvent onDeath;
    public TransformEvent onDeathTransform;

    int currenthealth;

    private void OnEnable()
    {
        currenthealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            onDeath.Invoke();
            onDeathTransform.Invoke(transform);
        }
    }
}
