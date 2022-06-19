using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private float damage = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() != null && other.tag == "Enemy")
        {
            Debug.Log($"Attacked {other.name}");
            Health health = other.GetComponent<Health>();
            health.UpdateHealth(-damage);
        }
    }
    private void Awake()
    {
        this.damage = transform.parent.parent.GetComponent<PlayerAttack>().playerWeapon.damage;
    }
}
