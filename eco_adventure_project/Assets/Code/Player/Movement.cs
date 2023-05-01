using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float jumpspeed = 3;

    private Rigidbody2D rb2D;
    private InputReader inputReader;
    private bool isJumping = false;
    private Vector2 direction = Vector2.zero;

    private float jumpRate = 0.5f;
    private float jumpTimer = 0;

    bool isGrounded;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        inputReader = GetComponent<InputReader>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Update()
    {
        direction = inputReader.GetMovement();
        bool isJumping = inputReader.IsJumping();
        if (!this.isJumping && isJumping)
        {
            this.isJumping = true;
        }
        UpdateJumpTimer(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move(direction);
        if (this.isJumping)
        {
            Jump();
            this.isJumping = false;
        }

    }

    private void UpdateJumpTimer(float deltaTime)
    {
        if (this.jumpTimer > 0)
        {
            this.jumpTimer -= deltaTime;
        }
    }

    public void Move(Vector2 direction)
    {
        Vector2 velocity = rb2D.velocity;
        velocity.x = direction.x * speed;
        rb2D.velocity = velocity;
    }

    public void Jump()
    {
        if (this.jumpTimer > 0)
        {
            return;
        }

        if (this.isGrounded)
        {
            rb2D.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
            this.jumpTimer = this.jumpRate;
        }
    }
}
