using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int level;
    public new string name;
    public float maxHealth, maxMana, maxStam;
    public float curHealth, curMana, curStam;
    public Slider healthBar;
    public Slider manaBar, stamBar;
    public Image healthFill, manaFill, staminaFill;



    public CheckPoint checkPoint;
    public Vector3 savePos;
    public float x, y, z;

    public static int gold;
    public static int exp;
    public Text _gold;
    public Text _exp;

    public void Start()
    {
        gold = 0;
        exp = 0;
    }

    public void SavePlayer()
    {
        savePos = transform.position;
        Save.SavePlayerData(this);

    }
    public void LoadPlayer()
    {
        DataToSave data = Save.LoadPlayerData();
        level = data.level;
        name = data.playerName;
        maxHealth = data.maxHealth;
        maxMana = data.maxMana;
        maxStam = data.maxStam;
        curHealth = data.curHealth;
        curMana = data.curMana;
        curStam = data.curStam;

        savePos = new Vector3(data.x, data.y, data.z);
        this.transform.position = savePos;


    }
    void Update()
    {
        // Clamp01 is maximum and minimum value (ex.between 0 and 1)
        healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        manaBar.value = Mathf.Clamp01(curMana / maxMana);
        stamBar.value = Mathf.Clamp01(curStam / maxStam);
        HealthManager();

        _gold.text = gold.ToString();
        _exp.text = exp.ToString();
    }
    void HealthManager()
    {
        //if health less than 0 and slider still enable = Dead and slider is disable
        if (curHealth <= 0 && healthFill.enabled)
        {
            Debug.Log("Dead");
            healthFill.enabled = false;
        }
        //else if is dead and health more than 0 = revive and enable slider
        else if (!healthFill.enabled && curHealth > 0) // ! = NOT
        {
            Debug.Log("Revived");
            healthFill.enabled = true;
        }
    }
}
