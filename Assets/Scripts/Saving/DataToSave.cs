using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    public int level;
    public string playerName;
    
    public float maxHealth, maxMana, maxStam;
    public float curHealth, curMana, curStam;
    public float x, y, z;




    public DataToSave(PlayerManager player)
    {
        level = player.level;
        playerName = player.name;
        curHealth = player.curHealth;
        curMana = player.curMana;
        curStam = player.curStam;
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStam = player.maxStam;

        x = player.savePos.x;
        y = player.savePos.y;
        z = player.savePos.z;
    }
}
	

