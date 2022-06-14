using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    Vector2 movement;
    private enum MovementState { idle, running }

    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Movement();
        UpdateAnimation();
    }
    private void Movement() => rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    private void UpdateAnimation()
    {
        MovementState state;
        //idle
        if (movement.x != 0f || movement.y != 0f)
        {
            state = MovementState.running;

            if (movement.x < 0f) //player to the left
                spriteRenderer.flipX = true;
            else if (movement.x > 0f) //player to the right
                spriteRenderer.flipX = false;
        }
        else //idle
            state = MovementState.idle;

        animator.SetInteger("state", (int)state);
    }
}
