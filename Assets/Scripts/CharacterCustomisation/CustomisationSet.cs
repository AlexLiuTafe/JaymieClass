using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//you will need to change Scenes
public class CustomisationSet : MonoBehaviour
{

    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex, mouthIndex, eyesIndex, armourIndex, clothesIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax, mouthMax, eyesMax, armourMax, clothesMax;
    [Header("Character Name")]
    //name of our character that the user is making
    public string charName = "Adventurer";
    [Header("Stats")]
    public characterClass charclass;
    public characterRace charRace;
    public int[] tempStats = new int[6];
    public int[] stats = new int[6];
    public string[] statArray = new string[6];
    public string[] selectedClass = new string[5];
    public int selectedIndex = 0;
    public int points = 10;

    [Header("Character Avatar Buttons")]
    public GameObject[] skinButtons;
    public GameObject[] hairButtons;
    public GameObject[] mouthButtons;
    public GameObject[] eyesButtons;
    public GameObject[] armourButtons;
    public GameObject[] clothesButtons;
    public GameObject resetButton;
    public GameObject randomButton;
    public GameObject playButton;
    public InputField playerNameInputField;//Test for name
    public static string playerName;//Test for name

    [Header("Character Class and Stats")]
    public GameObject[] classButtons;
    public GameObject[] strengthButtons;
    public GameObject[] dexterityButtons;
    public GameObject[] constitutionButtons;
    public GameObject[] wisdomButtons;
    public GameObject[] intelligenceButtons;
    public GameObject[] charismaButtons;
    public Text className;
    public Text pointText;
    #endregion

    #region Start
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //TEST FOR NAME
        if (playerName != null)
        {
            playerNameInputField.text = playerName;
        }

        pointText.text = "Points" + points.ToString(); //TESTING
        className.text = selectedClass[0]; //TESTING

        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Paladin", "Priest", "Rogue", "Ranger", "Wizard" };

        //in start we need to set up the following

        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of hair textures we need
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            Texture2D temp = Resources.Load("character/Hair_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of mouth textures we need  
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            Texture2D temp = Resources.Load("character/Mouth_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of eyes textures we need
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            Texture2D temp = Resources.Load("character/Eyes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the eyes List      
            eyes.Add(temp);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Clothes_#
            Texture2D temp = Resources.Load("character/Clothes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the eyes List      
            clothes.Add(temp);
        }
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Armour_#
            Texture2D temp = Resources.Load("character/Armour_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the eyes List      
            armour.Add(temp);
        }
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);

        //Set to Default Class
        //ChooseClass(0); //FOR GUI
        #region do this after making the function SetTexture
        
        #endregion
    }
    #endregion


    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    void SetTexture(string type, int dir)
    {
        //the string is the name of the material we are editing, the int is the direction we are changing
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        //we need variables that exist only within this function
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        //inside a switch statement that is swapped by the string name of our material
        #region Switch Material
        switch (type)
        {
            case "Skin"://case skin
                index = skinIndex;//index is the same as our skin index
                max = skinMax;//max is the same as our skin max
                textures = skin.ToArray();//textures is our skin list .ToArray()
                matIndex = 1;//material index element number is 1
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 6;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 5;
                break;

        }

        #endregion
        #region OutSide Switch
        index += dir;//index plus equals our direction
        if (index < 0)//cap our index to loop back around if is is below 0 or above max take one
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = character.materials;//Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;//our characters materials are equal to the material array

        #endregion

        #region Set Material Switch
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;

        }

        #endregion
    }
    #endregion

    #region Save
    void Save()
    {

        //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex,Armour,Clothes
        CharCustomSaveData.SavePlayerData(this);
        //SetString CharacterName

    }

    #endregion

    #region OnGUI
    //private void OnGUI()
    //{
    //    //create the floats scrW and scrH that govern our 16:9 ratio
    //    float scrW = Screen.width / 16;
    //    float scrH = Screen.height / 9;

    //    #region Skin
    //    int i = 0;//create an int that will help with shuffling your GUI elements under eachother
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
    //    {
    //        SetTexture("Skin", -1);
    //    }
    //    GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Skin");
    //    if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
    //    {
    //        SetTexture("Skin", 1);
    //    }
    //    i++;
    //    #endregion
    //    #region Hair
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
    //    {
    //        SetTexture("Hair", -1);
    //    }
    //    GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Hair");
    //    if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
    //    {
    //        SetTexture("Hair", 1);
    //    }
    //    i++;
    //    #endregion
    //    #region Mouth
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
    //    {
    //        SetTexture("Mouth", -1);
    //    }
    //    GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Mouth");
    //    if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
    //    {
    //        SetTexture("Mouth", 1);
    //    }
    //    i++;
    //    #endregion
    //    #region Eyes
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
    //    {
    //        SetTexture("Eyes", -1);
    //    }
    //    GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Eyes");
    //    if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
    //    {
    //        SetTexture("Eyes", 1);
    //    }
    //    i++;
    //    #endregion
    //    #region Armour
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
    //    {
    //        SetTexture("Armour", -1);
    //    }
    //    GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Armour");
    //    if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
    //    {
    //        SetTexture("Armour", 1);
    //    }
    //    i++;
    //    #endregion
    //    #region Clothes
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
    //    {
    //        SetTexture("Clothes", -1);
    //    }
    //    GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Clothes");
    //    if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
    //    {
    //        SetTexture("Clothes", 1);
    //    }
    //    i++;
    //    #endregion
    //    #region Random Reset
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Reset"))
    //    {
    //        SetTexture("Skin", skinIndex = 0);
    //        SetTexture("Hair", hairIndex = 0);
    //        SetTexture("Mouth", mouthIndex = 0);
    //        SetTexture("Eyes", eyesIndex = 0);
    //        SetTexture("Armour", armourIndex = 0);
    //        SetTexture("Clothes", clothesIndex = 0);
    //    }
    //    if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
    //    {
    //        SetTexture("Skin", Random.Range(0, skinMax - 1));
    //        SetTexture("Hair", Random.Range(0, hairMax - 1));
    //        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
    //        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
    //        SetTexture("Armour", Random.Range(0, armourMax - 1));
    //        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
    //    }
    //    i++;
    //    charName = GUI.TextField(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), charName, 16);
    //    i++;
    //    #region Save and play button  
    //    if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Save and Play")) 
    //    {
    //        Save();
    //        SceneManager.LoadScene(1);
    //    }
    //    i = 0;
    //    #endregion
    //    GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Class");
    //    i++;

    //    if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
    //    {
    //        selectedIndex--;
    //        if (selectedIndex < 0)
    //        {
    //            selectedIndex = selectedClass.Length - 1;
    //        }
    //        ChooseClass(selectedIndex);
    //    }
    //    GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), selectedClass[selectedIndex]);
    //    if (GUI.Button(new Rect(5.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
    //    {
    //        selectedIndex++;
    //        if (selectedIndex > selectedClass.Length - 1)
    //        {
    //            selectedIndex = 0;
    //        }
    //        ChooseClass(selectedIndex);
    //    }
    //    GUI.Box(new Rect(3.75f * scrW, 2 * scrH, 2 * scrW, 0.5f * scrH), "Points" + points);
    //    for (int s = 0; s < 6; s++)
    //    {
    //        if (points > 0)
    //        {
    //            if (GUI.Button(new Rect(5.75f * scrW, 2.5f * scrH + s * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
    //            {
    //                points--;
    //                tempStats[s]++;
    //            }
    //        }
    //        GUI.Box(new Rect(3.75f * scrW, 2.5f * scrH + s * (0.5f * scrH), 2 * scrW, 0.5f * scrH), statArray[s] + ":" + (tempStats[s]+stats[s]));
    //        if (points < 10 && tempStats[s] > 0)
    //        {
    //            if (GUI.Button(new Rect(3.25f * scrW, 2.5f * scrH + s * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
    //            {
    //                points++;
    //                tempStats[s]--;
    //            }
    //        }
    //    }

    //    #endregion
    //}
    void ChooseClass(int className)
    {
        switch (className)
        {
            case 0:
                stats[0] = 15;
                stats[1] = 5;
                stats[2] = 12;
                stats[3] = 6;
                stats[4] = 6;
                stats[5] = 5;
                charclass = characterClass.Paladin;
                break;
            case 1:
                stats[0] = 5;
                stats[1] = 8;
                stats[2] = 5;
                stats[3] = 12;
                stats[4] = 10;
                stats[5] = 10;
                charclass = characterClass.Priest;
                break;

            case 2:
                stats[0] = 5;
                stats[1] = 15;
                stats[2] = 8;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 9;
                charclass = characterClass.Ranger;
                break;
            case 3:
                stats[0] = 6;
                stats[1] = 18;
                stats[2] = 8;
                stats[3] = 5;
                stats[4] = 5;
                stats[5] = 15;
                charclass = characterClass.Rogue;
                break;
            case 4:
                stats[0] = 5;
                stats[1] = 7;
                stats[2] = 5;
                stats[3] = 18;
                stats[4] = 15;
                stats[5] = 7;
                charclass = characterClass.Wizard;
                break;
        }
    }

    #endregion
    #region CANVAS FUNCTIONS
    public void SkinButton()
    {
        if (skinButtons[0])
        {
            SetTexture("Skin", -1);
        }
        else if (skinButtons[1])
        {
            SetTexture("Skin", 1);
        }
    }
    public void HairButton()
    {
        if (skinButtons[0])
        {
            SetTexture("Hair", -1);
        }
        else if (skinButtons[1])
        {
            SetTexture("Hair", 1);
        }
    }
    public void MouthButton()
    {
        if (skinButtons[0])
        {
            SetTexture("Mouth", -1);
        }
        else if (skinButtons[1])
        {
            SetTexture("Mouth", 1);
        }
    }
    public void EyesButton()
    {
        if (skinButtons[0])
        {
            SetTexture("Eyes", -1);
        }
        else if (skinButtons[1])
        {
            SetTexture("Eyes", 1);
        }
    }
    public void ArmourButton()
    {
        if (skinButtons[0])
        {
            SetTexture("Armour", -1);
        }
        else if (skinButtons[1])
        {
            SetTexture("Armour", 1);
        }
    }
    public void ClothesButton()
    {
        if (skinButtons[0])
        {
            SetTexture("Clothes", -1);
        }
        else if (skinButtons[1])
        {
            SetTexture("Clothes", 1);
        }
    }
    public void ResetButton()
    {
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
    }
    public void RandomButton()
    {
        SetTexture("Skin", Random.Range(0, skinMax - 1));
        SetTexture("Hair", Random.Range(0, hairMax - 1));
        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
        SetTexture("Armour", Random.Range(0, armourMax - 1));
        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
    }
    public void PlayButton()
    {
        Save();
        SceneManager.LoadScene(1);
        SaveName(playerName);//Test for name
    }
    public void SaveName(string newName)
    {
        playerName = newName;
    }
    public void SelectClass()
    {
        if (classButtons[0])
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = selectedClass.Length - 1;
            }
            ChooseClass(selectedIndex);
        }
        if(classButtons[1])
        {
            selectedIndex++;
            if (selectedIndex > selectedClass.Length -1)
            {
                selectedIndex = 0;
            }
            ChooseClass(selectedIndex);
        }
    }
    #endregion
}

public enum characterClass
{
    Paladin,
    Priest,
    Ranger,
    Rogue,
    Wizard
}
public enum characterRace
{
    Dragonborn,
    Dwarf,
    Elf,
    Gnome,
    Half_Elf,
    Half_Orc,
    Halfling,
    Human,
    Tiefling
}