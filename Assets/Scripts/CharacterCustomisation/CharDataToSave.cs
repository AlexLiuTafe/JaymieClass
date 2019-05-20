using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharDataToSave
{

    public int skin;
    public int hair, mouth, eyes, armour, clothes;
    public string characterName;

    public CharDataToSave(CustomisationSet custom)
    {
        skin = custom.skinIndex;
        hair = custom.hairIndex;
        mouth = custom.mouthIndex;
        eyes = custom.eyesIndex;
        armour = custom.armourIndex;
        clothes = custom.clothesIndex;

        characterName = custom.charName;

    }
}

