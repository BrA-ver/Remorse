using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    [SerializeField] float maxSpeed = 7.5f;

    public Vector2 Velocity { get { return rb.linearVelocity; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = direction * maxSpeed;
        rb.linearVelocity = velocity;
    }

    public void Move(Vector2 newDir)
    {
        direction = newDir;
    }
}
