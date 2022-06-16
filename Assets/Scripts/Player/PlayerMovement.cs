using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameData pD;
    private Rigidbody2D rb;
    private Animator animator;
    Vector2 movement;
    private enum MovementState { idle, running }

    public float moveSpeed = 5f;
    public PlayerInputActions playerControls;
    private InputAction move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/
        movement = move.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Movement();
        UpdateAnimation();
    }
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        pD = GetComponent<PlayerData>().playerData;
    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }
    void OnDisable()
    {
        move.Disable();
    }
    private void Movement() => rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    private void UpdateAnimation()
    {
        MovementState state;
        //idle
        if (movement.x != 0f || movement.y != 0f)
            state = MovementState.running;
        else //idle
            state = MovementState.idle;

        animator.SetInteger("state", (int)state);
    }
}
