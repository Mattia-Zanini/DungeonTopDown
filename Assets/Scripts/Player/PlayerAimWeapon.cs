using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weaponRender;
    public bool followMouse;
    private float angle;
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        spriteRenderer = GetComponent<SpriteRenderer>();
        weaponRender = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        followMouse = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleAim(followMouse);
        UpdatePlayerDirection(angle);
    }
    private void HandleAim(bool follow)
    {
        if (follow)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; //Mathf.Rad2Deg per convertire da radianti a gradi
            //Debug.Log(angle);
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
    private void UpdatePlayerDirection(float angle)
    {
        //player to the right
        if (angle >= -90 && angle <= 90)
        {
            spriteRenderer.flipX = false;
            weaponRender.flipX = false;
        }
        //player to the left
        else
        {
            spriteRenderer.flipX = true;
            weaponRender.flipX = true;
        }
    }




    //Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) => worldCamera.ScreenToWorldPoint(screenPosition);
}
