using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction attack;
    private GameObject attackArea = default;
    public Weapon playerWeapon;
    private Animator swordAnim;

    private bool attaccking = false;
    [SerializeField] private float timeToAttack = 0.5f;
    [SerializeField] private float attackDuration = 0.2f;
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
        SwordAttack();
    }
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        GetWeapon();
        swordAnim = transform.GetChild(0).GetChild(1).GetComponent<Animator>();
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
            attaccking = true;
            if (PlayerHaveSword())
            {
                attackArea.SetActive(attaccking);
                swordAnim.SetBool("attack", true);
                GetComponent<PlayerAimWeapon>().followMouse = false;
            }
        }
    }
    private void SwordAttack()
    {
        if (attaccking && PlayerHaveSword())
        {
            timer += Time.deltaTime;
            if (timer >= attackDuration)
            {
                attackArea.SetActive(false);
            }
            if (timer >= timeToAttack)
            {
                timer = 0f;
                attaccking = false;
                swordAnim.SetBool("attack", false);
                GetComponent<PlayerAimWeapon>().followMouse = true;
            }
        }
    }
    private bool PlayerHaveSword() => playerWeapon.isMelee;
    private void GetWeapon()
    {
        GameData data = gameObject.GetComponent<PlayerData>().playerData;
        playerWeapon = data.weapons[data.selectedWeapon];
    }
}
