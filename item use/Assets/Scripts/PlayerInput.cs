using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Jump Settings")]
    [SerializeField] private KeyCode JumpKey = KeyCode.Space;
    [SerializeField] private float jumpPower = 5f;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint; 
    [SerializeField] private float checkRadius = 0.2f;    
    [SerializeField] private LayerMask groundLayer;      

    private Vector2 moveVector;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, rigidbody2D.velocity.y);
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
        return Input.GetKeyDown(JumpKey) && GroundCheck();
    }

    private bool GroundCheck()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        Color debugColor = isGrounded ? Color.green : Color.red;
        Debug.DrawLine(groundCheckPoint.position, groundCheckPoint.position + Vector3.down * 0.05f, debugColor);

        return isGrounded;
    }
}
