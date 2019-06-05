using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//you will need to change Scenes
public class CustomisationGet : MonoBehaviour {

    [Header("Character")]
    //public variable for the Skinned Mesh Renderer which is our character reference
    public Renderer character;
    public CustomisationSet customSet;
    [Header("Customisation")]
    public int skin;
    public int hair, mouth, eyes, armour, clothes;
    public string characterName;
    public Text playerNameText;

    #region Start
    private void Start()
    {
        //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
        character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>();
        //Run the function LoadTexture
        LoadTexture();
    
    }

    #endregion

    #region LoadTexture Function
    void LoadTexture()
    {
        string path = Application.persistentDataPath + "/customChar.png";
        //check to see if our save file for this character
        if(File.Exists(path))//if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes from PlayerPrefs
        {
            CharDataToSave data = CharCustomSaveData.LoadPlayerData();
            SetTexture("Skin", data.skin);
            skin = data.skin;
            SetTexture("Hair", data.hair);
            hair = data.hair;
            SetTexture("Mouth", data.mouth);
            mouth = data.mouth;
            SetTexture("Eyes", data.eyes);
            eyes = data.eyes;
            SetTexture("Armour", data.armour);
            armour = data.armour;
            SetTexture("Clothes", data.clothes);
            clothes = data.clothes;
            //grab the gameObject in scene that is our character and set its Object name to the Characters name
            characterName = data.characterName; // FOR GUI
            //playerName = data.characterName.ToString; //FOR CANVAS

        }
        else//if it doesnt then load the CustomSet level
        {
            SetTexture("Skin", customSet.skinIndex = 0);
            SetTexture("Hair", customSet.hairIndex = 0);
            SetTexture("Mouth", customSet.mouthIndex = 0);
            SetTexture("Eyes", customSet.eyesIndex = 0);
            SetTexture("Armour", customSet.armourIndex = 0);
            SetTexture("Clothes", customSet.clothesIndex = 0);
            //grab the gameObject in scene that is our character and set its Object name to the Characters name
            characterName = customSet.charName;

        }
            
    }

    #endregion
    #region SetTexture
    void SetTexture(string type, int index)
    {

        //the string is the name of the material we are editing, the int is the direction we are changing

        //we need variables that exist only within this function
        //these are int material index and Texture2D array of textures
        Texture2D tex = null;
        int matIndex = 0;
        //inside a switch statement that is swapped by the string name of our material
        switch(type)
        {
            case "Skin":
                //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;//material index element number is 1
                break;

            case "Hair":
                tex = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "Mouth":
                tex = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "Eyes":
                tex = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 2;
                break;
            case "Armour":
                tex = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 5;
                break;
            case "Clothes":
                tex = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 6;
                break;
        }

        //Material array is equal to our characters material list
        Material[] mats = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mats[matIndex].mainTexture = tex;
        //our characters materials are equal to the material array
        character.materials = mats;
    }

    #endregion
}
