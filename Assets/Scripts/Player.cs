using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = true;
    public bool canDoubleJump = false;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private float topScore = 0.0f;

    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) // Checks if the player is grounded by the time the Space button is pressed
            {
                CanJump(); // Jump!
                canDoubleJump = true; // Allow the player to jump a second time
            }
            else if (canDoubleJump)
            {
                CanJump(); // Jump again!
                canDoubleJump = false; // Can't double jump anymore
            }
        }

        if(rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y; // Turn the top score into player's y position
        }

        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true; // If the player touches an object with the Ground tag, isGrounded is set to true
        }

        if(collision.collider.tag == "Death")
        {
            SceneManager.LoadScene(0); // If the player touches the barrier tagged with Death, the scene restarts
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
