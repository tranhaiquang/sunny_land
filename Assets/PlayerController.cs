using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float dirX = 0f;
    private float dirY = 0f;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("is_jumping", true);
        }
        else 
        {
            animator.SetBool("is_jumping", false);
        }

        updateAnimation();
        
    }

    private void updateAnimation() 
    {
        if (dirY > 0) 
        {
            animator.SetBool("is_jumping", true);
        }
        else 
        {
            animator.SetBool("is_jumping", false);
        }
        
        if (dirX > 0f)
        {
            animator.SetBool("is_running", true);
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            animator.SetBool("is_running", true);
            spriteRenderer.flipX = true;
        }
        else 
        {
            animator.SetBool("is_running", false);
        }
    }
}
