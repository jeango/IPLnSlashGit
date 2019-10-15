using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using IPL.EventTypes;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Values")]
    [SerializeField]
    int initHealth = 0;

    Transform myTransform;

    [Header("Events")]
    public UnityEvent onDeath;
    public TransformEvent onDeathTransform;

    int currenthealth;

    private void OnEnable()
    {
        myTransform = transform;
        currenthealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            onDeathTransform.Invoke(myTransform);
            onDeath.Invoke();
        }
    }

    [ContextMenu("Test Damage")]
    public void TestDamage()
    {
        TakeDamage(1);
    }

}
