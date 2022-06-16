using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public string name;
    public int id;
    public bool isMelee;
    public float damage;
    public Weapon(string name, int id, bool isMelee, float damage)
    {
        this.name = name;
        this.id = id;
        this.isMelee = isMelee;
        this.damage = damage;
    }
    public string GetName() => name;
    public int GetId() => id;
    public bool IsMelee() => isMelee;
    public float GetDamage() => damage;
}
