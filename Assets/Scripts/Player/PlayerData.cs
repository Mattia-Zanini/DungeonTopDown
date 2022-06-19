using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IDataManager
{
    public GameData playerData;
    private void Awake()
    {
        ////experimental
        if (playerData.weapons.Count == 0)
            playerData.weapons.Add(new Weapon("Great Sword", 0, true, 25));
    }
    public void LoadData(GameData data)
    {
        this.playerData = data;
        this.transform.position = playerData.playerPosition;
    }
    public void SaveData(ref GameData data)
    {
        this.playerData.playerPosition = this.transform.position;
        data = this.playerData;
    }
}
