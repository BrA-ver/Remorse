using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseDistance = .5f;

    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 15f;

    // Spawning
    public UnityEvent<Enemy> onEnemyDestroy;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    private void OnDestroy()
    {
        onEnemyDestroy.Invoke(this);
    }

    private void Update()
    {
        if (!target) 
        {
            Stop();
            return; 
        }

        LookAtPlayer();

        bool closeToPlayer = Vector2.Distance(transform.position, target.position) <= chaseDistance;
        if (!closeToPlayer)
        {
            direction = target.position - transform.position;
            direction.Normalize();
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVel = direction * moveSpeed;
        Vector2 velocity = Vector2.MoveTowards(rb.linearVelocity, targetVel, acceleration * Time.deltaTime);
        rb.linearVelocity = velocity;
    }

    void LookAtPlayer()
    {
        if (target.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (target.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    void Stop()
    {
        direction = Vector2.zero;
    }
}
