using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = true;
    public bool canDoubleJump = false;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                CanJump();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                CanJump();
                canDoubleJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void CanJump()
    {
        rb.velocity = Vector2.up * jumpHeight;
    }
}
