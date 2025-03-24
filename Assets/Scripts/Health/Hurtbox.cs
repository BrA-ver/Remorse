using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : DamageSource
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Hitbox hitbox = other.GetComponent<Hitbox>();

        if (hitbox) hitbox.TakeDamage(damage);
    }
}
