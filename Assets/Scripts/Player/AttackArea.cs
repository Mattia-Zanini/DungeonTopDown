using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() != null && other.tag == "Enemy")
        {
            Debug.Log($"Attacked {other.name}");
            Health health = other.GetComponent<Health>();
            health.UpdateHealth(-damage);
        }
    }
}
