using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth = 100;
    private const int death = 0;

    private void Start()
    {
        health = maxHealth;
    }
    public void UpdateHealth(float healthModifier)
    {
        health += healthModifier;
        Debug.Log($"{this.gameObject.name} get {healthModifier} of health");
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= death)
        {
            health = death;
            Debug.Log($"{this.gameObject.name} is died");
            Destroy(gameObject);
        }
    }
}
