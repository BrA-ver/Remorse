using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 10;
    [SerializeField] protected int currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public float HealthRatio => (float)currentHealth / (float)maxHealth;

    protected virtual void Start()
    {
        ResetHealth();
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    protected void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
