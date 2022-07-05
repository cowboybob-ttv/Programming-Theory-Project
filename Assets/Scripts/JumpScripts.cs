using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScripts : MonoBehaviour
{
    //Varibles for jump with ridgid body
    public Rigidbody2D rb;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    
    //Varibles for jump without ridgid body
    public GroundCheck groundCheck;
    public float jumpHeight;
    public float jumpForce=20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;

    //Raycast jump variables
    public bool isGrounded;
    public float offset = 0.1f;
    public Vector2 surfacePosition;
    ContactFilter2D filter;
    Collider2D[] results = new Collider2D[1];


    //Jump based on time button is pressed down for 2d adding velocity while jumping is true
    public void JumpRigidbody()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jumping = true;
            jumpTime = 0;
        }
        if(jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
    }

    public void VariableJumpRigidbody()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }
    
    private void FixedUpdate()
    {
        if(jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }
    
    //jump without rigidbody checks if grounded to stop falling or jump while jumping using collider
    public void ManualJump()
    {
        velocity += gravity * gravityScale * Time.deltaTime;
        if (groundCheck.isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = jumpForce;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    public void RayCastJump()
    {
        Vector2 point = transform.position + Vector3.down * offset;
        Vector2 size = new Vector2(transform.localScale.x, transform.localScale.y);
        if (Physics2D.OverlapBox(point, size, 0, filter.NoFilter(), results) > 0)
        {
            isGrounded = true;
            surfacePosition = Physics2D.ClosestPoint(transform.position, results[0]);
        }
        else 
        {
            isGrounded = false;
        }
    }
}