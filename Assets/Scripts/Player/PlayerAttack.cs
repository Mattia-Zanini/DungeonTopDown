using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction attack;

    private GameObject attackArea = default;
    private GameData playerData;
    private bool attaccking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).GetChild(0).gameObject;
        attackArea.SetActive(attaccking);
        playerData = gameObject.GetComponent<PlayerData>().playerData;
    }

    // Update is called once per frame
    void Update()
    {
        SwordAttack(PlayerHaveSword());
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
            attaccking = true;
            if(PlayerHaveSword())
                attackArea.SetActive(attaccking);
        }
    }
    private void SwordAttack(bool haveSword)
    {
        if (attaccking && haveSword)
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
    private bool PlayerHaveSword() => playerData.weapons[playerData.selectedWeapon].isMelee;
}
