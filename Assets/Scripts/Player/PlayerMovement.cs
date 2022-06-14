using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IDataManager
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    Vector2 movement;
    private enum MovementState { idle, running }

    public float moveSpeed = 5f;
    public PlayerInputActions playerControls;
    private InputAction move;
    private InputAction attack;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        attack = playerControls.Player.Fire;
        attack.Enable();
        attack.performed += Attack;
    }
    void OnDisable()
    {
        move.Disable();
        attack.Disable();
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

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
        /*movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/
        movement = move.ReadValue<Vector2>();
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
    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }
}
