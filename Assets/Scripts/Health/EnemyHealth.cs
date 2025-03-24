using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
