﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public static int money;
    public Item selectedItem;

    public Vector2 scr;
    public Vector2 scrollPos;

    public string[] sortTypes;
    public string selectedType;

    public Transform[] equippedLocations;
    /*
     0 = right hand
     1 = left hand
     */

    public Transform dropLocation;
    public GameObject curWeapon;
    public GameObject curHelm;
    public PlayerManager player; // for refencing HealthBar

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sortTypes = new string[] { "All", "Food", "Weapon", "Apparel", "Crafting", "Quest", "Ingredient", "Potion", "Quest" };
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(302));
        inv.Add(ItemData.CreateItem(400));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(601));
        inv.Add(ItemData.CreateItem(602));
        inv.Add(ItemData.CreateItem(700));
        inv.Add(ItemData.CreateItem(701));
        inv.Add(ItemData.CreateItem(702));

        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }

    }
    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            return false;
        }
        else
        {
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            return true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if game if not paused
            if (PauseMenu.GameIsPause == false)
            {
                ToggleInv();
            }

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(0));
            inv.Add(ItemData.CreateItem(1));
            inv.Add(ItemData.CreateItem(2));
            inv.Add(ItemData.CreateItem(100));
            inv.Add(ItemData.CreateItem(101));
            inv.Add(ItemData.CreateItem(102));
            inv.Add(ItemData.CreateItem(200));
            inv.Add(ItemData.CreateItem(201));
            inv.Add(ItemData.CreateItem(202));
            inv.Add(ItemData.CreateItem(300));
            inv.Add(ItemData.CreateItem(301));
            inv.Add(ItemData.CreateItem(302));
            inv.Add(ItemData.CreateItem(400));
            inv.Add(ItemData.CreateItem(401));
            inv.Add(ItemData.CreateItem(402));
            inv.Add(ItemData.CreateItem(500));
            inv.Add(ItemData.CreateItem(501));
            inv.Add(ItemData.CreateItem(502));
            inv.Add(ItemData.CreateItem(600));
            inv.Add(ItemData.CreateItem(601));
            inv.Add(ItemData.CreateItem(602));
            inv.Add(ItemData.CreateItem(700));
            inv.Add(ItemData.CreateItem(701));
            inv.Add(ItemData.CreateItem(702));
        }
    }
    void DisplayInv(string sortType)
    {
        //if we pick a type
        if (!(sortType == "All" || sortType == ""))
        {
            ItemType type = (ItemType)
                System.Enum.Parse(typeof(ItemType), sortType);
            int a = 0; //amount of that type
            int s = 0;//slot position of item
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)//Find our type
                {
                    a++;//increase the amount of this type
                }
            }
            //If The amount of this type is less or equal to the amount we can display on the screen without scrolling
            if (a <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    //if its the type we want to display
                    if (inv[i].Type == type)
                    {
                        //we display a button that is of this type and slot them under the last one

                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];//select the time from its position in the inventory
                            Debug.Log(selectedItem.Name);
                        }
                        s++;//increase the slot pos so the next one slides under

                    }
                }
            }
            else // if more than amount of viewable items
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos,
                    new Rect(0, 0, 0, 8.5f * scr.y + ((a - 34) * (0.25f * scr.y))), true, true);
                #region Items in viewing Area
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0, s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];//select the item from its position in the inventory
                            Debug.Log(selectedItem.Name);
                        }
                        s++;//increase the slot pos so the next one slides under
                    }
                }
                #endregion
                GUI.EndScrollView();
            }

        }
        //if we are viewing All
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos,
                   new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);

                #region Items in viewing Area
                for (int i = 0; i < inv.Count; i++)
                {

                    if (GUI.Button(new Rect(0, i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];//select the item from its position in the inventory
                        Debug.Log(selectedItem.Name);
                    }

                }
                #endregion
                GUI.EndScrollView();

            }
        }
    }
    void DisplayItem()
    {
        switch (selectedItem.Type)
        {
            //NOTE* Only Healing Items have the Heal variable
            case ItemType.Food:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (player.curHealth < player.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                    {
                        player.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            //Wepon Region
            case ItemType.Weapon:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage + "\nAmount: " + selectedItem.Amount);

                EquipItem(curWeapon, 0);//Equip Button is already in the function

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Apparel:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nArmour: " + selectedItem.Armour + "\nAmount: " + selectedItem.Amount);

                EquipItem(curHelm, 1);//Equip Button is already in the function

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Crafting:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {

                    DepleteAmount();
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Quest:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {

                    DepleteAmount();
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Ingredient:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {

                    DepleteAmount();
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Potion:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (player.curHealth < player.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Drink"))
                    {
                        player.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Scroll:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description +
                    "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {

                    DepleteAmount();
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            default:
                break;
        }
    }
    void DepleteAmount()
    {
        if (selectedItem.Amount > 1)
        {
            selectedItem.Amount--;
        }
        else
        {
            inv.Remove(selectedItem);
            selectedItem = null;
        }
        return;

    }
    void Discard()
    {
        if (selectedItem.Type == ItemType.Weapon)
        {
            if (curWeapon != null && selectedItem.Mesh.name == curWeapon.name)
            {
                Destroy(curWeapon);
            }

        }
        else if (selectedItem.Type == ItemType.Apparel)
        {
            if (curHelm != null && selectedItem.Mesh.name == curHelm.name)
            {
                Destroy(curHelm);
            }
        }

        GameObject clone = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
        clone.AddComponent<Rigidbody>().useGravity = true; // attached rigidbody and gravity so it will fall to ground
        if (clone.GetComponent<Collider>() == null)
        {
            clone.AddComponent<BoxCollider>();

        }
        DepleteAmount();
    }
    void EquipItem(GameObject item, int location)
    {
        if (item == null || selectedItem.Mesh.name != item.name)
        {
            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25F * scr.y), "Equip"))
            {
                if (item != null)
                {
                    Destroy(item);
                }
                //Equip the items into the location
                item = Instantiate(selectedItem.Mesh, equippedLocations[location]);

                if(selectedItem.Type == ItemType.Weapon)
                {
                    curWeapon = item;
                }
                else if(selectedItem.Type ==ItemType.Apparel)
                {
                    curHelm = item;
                }

                if (item.GetComponent<ItemHandler>() != null)
                {
                    item.GetComponent<ItemHandler>().enabled = false;
                }
                item.name = selectedItem.Mesh.name;
            }
            else
            {
                if (item != null && selectedItem.Mesh.name == item.name)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25F * scr.y), "UnEquip"))
                    {

                        Destroy(item);

                    }
                }
            }
        }

    }
    private void OnGUI()
    {
        
        if (showInv)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            for (int i = 0; i < sortTypes.Length; i++)
            {
                if (GUI.Button(new Rect(5.5f * scr.x + i * (scr.x), 0.25f * scr.y, scr.x, 0.25f * scr.y), sortTypes[i]))
                {
                    selectedType = sortTypes[i];
                }
            }
            DisplayInv(selectedType);
            if (selectedItem != null)
            {
                DisplayItem();
                GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
            }
        }

    }
}
