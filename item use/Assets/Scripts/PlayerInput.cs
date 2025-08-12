using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float groundDistance = 1.2f;
    [SerializeField] private LayerMask groundLayer;

    private Vector2 moveVector;
    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (CanJump())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        }
    }

    private bool CanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && GroundCheck();
    }

    private bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        return hit.collider != null;
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, rigidbody2D.velocity.y);
    }
}
