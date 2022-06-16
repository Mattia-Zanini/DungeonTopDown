using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int deathCounts;
    public Vector2 playerPosition;
    public ulong floor;
    public List<Weapon> weapons;
    public int health;
    public int selectedWeapon;
    public GameData()
    {
        this.deathCounts = 0;
        this.playerPosition = Vector2.zero;
        this.floor = 0;
        this.health = 100;
        this.weapons = new List<Weapon>();
        this.selectedWeapon = 0;
    }
}
