using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DamageSource
{
    [SerializeField] float lifeTime = 15f;
    [SerializeField] GameObject hitEffect;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Hitbox hitbox = other.GetComponent<Hitbox>();
        if (hitbox)
        {
            hitbox.TakeDamage(damage);
        }
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
