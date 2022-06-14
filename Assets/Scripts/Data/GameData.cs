using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int deathCounts;
    public Vector2 playerPosition;
    public ulong floor;
    public GameData()
    {
        this.deathCounts = 0;
        this.playerPosition = Vector2.zero;
        this.floor = 0;
    }
}
