using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharDataToSave
{

    public int skin;
    public int hair, mouth, eyes, armour, clothes;
    public int strength, dexterity, constitution, wisdom, intelligence, charisma;
    public string characterName;
    public string charClass;
    public string charRace;
    public int health;
    public int mana;
    
    public CharDataToSave(CustomisationSet custom)
    {
        //Textures
        skin = custom.skinIndex;
        hair = custom.hairIndex;
        mouth = custom.mouthIndex;
        eyes = custom.eyesIndex;
        armour = custom.armourIndex;
        clothes = custom.clothesIndex;
        //Stats
        strength = custom.stats[0] + custom.tempStats[0];
        dexterity =custom.stats[1] + custom.tempStats[1];
        constitution = custom.stats[2] + custom.tempStats[2];
        wisdom = custom.stats[3] + custom.tempStats[3];
        intelligence = custom.stats[4] + custom.tempStats[4];
        charisma = custom.stats[5] + custom.tempStats[5];
        //Char Class
        charClass = custom.className.text;
        //Char Race
        charRace = custom.raceName.text;
        health = custom.health;
        mana = custom.mana;
        //charRace = custom
        //characterName = custom.charName; //FOR GUI
        characterName = custom.charName; //FOR CANVAS
    }
}

