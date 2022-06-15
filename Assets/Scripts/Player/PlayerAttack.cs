using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction attack;
    private float angle;

    private GameObject attackArea = default;
    private bool attaccking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).GetChild(0).gameObject;
        attackArea.SetActive(attaccking);
    }

    // Update is called once per frame
    void Update()
    {
        if (attaccking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0f;
                attaccking = false;
                attackArea.SetActive(attaccking);
            }
        }
    }
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    void OnEnable()
    {
        attack = playerControls.Player.Fire;
        attack.Enable();
        attack.performed += Attack;
    }
    void OnDisable()
    {
        attack.Disable();
    }
    private void Attack(InputAction.CallbackContext context)
    {
        if (!attaccking)
        {
            Debug.Log("Attack");
            attaccking = true;
            attackArea.SetActive(attaccking);
        }
    }
}
