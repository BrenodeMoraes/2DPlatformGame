using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer playerSprite;
    private BoxCollider2D coll; 
    private float H = 0f;
    private float moveSpeed = 7f;
    private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private enum movementState { idle, isRunning, isJumping, isFalling };

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        H = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(H * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        movementState state;

        if (H > 0f)
        {
            state = movementState.isRunning;
            playerSprite.flipX = false;
        }
        else if (H < 0f)
        {
            state = movementState.isRunning;
            playerSprite.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.isJumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.isFalling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
