using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerInput input;
    PlayerMovement movement;
    Animator anim;

    Gun gun;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();

        gun = GetComponentInChildren<Gun>();
    }
    private void Update()
    {
        Move();
        AnimatePlayer();
        MouseFlip();

        if (input.Shoot)
        {
            gun.Shoot();
        }
    }

    private void Move()
    {
        Vector2 moveInput = input.MoveInput;
        movement.Move(moveInput);
    }

    void AnimatePlayer()
    {
        bool moving = movement.Velocity.sqrMagnitude > 0.1f && input.MoveInput.sqrMagnitude > 0.1f;
        anim.SetBool("moving", moving);
    }

    void MouseFlip()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (mousePos.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
