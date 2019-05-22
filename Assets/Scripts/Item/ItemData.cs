using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        int heal = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;

        switch (itemID)
        {
            #region Food 0-99
            case 0:
                name = "Apple";
                value = 5;
                description = "Yum Yum";
                icon = "Food/Apple_Icon";
                mesh = "Food/Apple_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
            case 1:
                name = "Coconut";
                value = 30;
                description = "Yup I am a nut";
                icon = "Food/Coconut_Icon";
                mesh = "Food/Coconut_Mesh";
                type = ItemType.Food;
                heal = 20;
                amount = 1;
                break;
            case 2:
                name = "Coffee";
                value = 15;
                description = "Zoom Zoom";
                icon = "Food/Coffee_Icon";
                mesh = "Food/Coffee_Mesh";
                type = ItemType.Food;
                heal = 10;
                amount = 1;
                break;


            #endregion
            #region Weapons 100- 199
            case 100:
                name = "Kitchen Knife";
                value = 30;
                description = "Kitchen USE ONLY";
                icon = "Weapon/KitchenKnife_Icon";
                mesh = "Weapon/KitchenKnife_Mesh";
                type = ItemType.Weapon;
                damage = 10;
                amount = 1;
                break;
            case 101:
                name = "Hammer";
                value = 150;
                description = "Kitchen Tenderiser";
                icon = "Weapon/Hammer_Icon";
                mesh = "Weapon/Hammer_Mesh";
                type = ItemType.Weapon;
                damage = 20;
                amount = 1;
                break;
            case 102:
                name = "Gun";
                value = 300;
                description = "Easy Win";
                icon = "Weapon/Gun_Icon";
                mesh = "Weapon/Gun_Mesh";
                type = ItemType.Weapon;
                damage = 100;
                amount = 1;
                break;
            #endregion
            #region Apparels 200-299
            case 200:
                name = "Shirt";
                value = 5;
                description = "Laundry Time";
                icon = "Apparel/Shirt_Icon";
                mesh = "Apparel/Shirt_Mesh";
                type = ItemType.Apparel;
                armour = 5;
                amount = 1;
                break;
            case 201:
                name = "Ring";
                value = 500;
                description = "My Precious";
                icon = "Apparel/Ring_Icon";
                mesh = "Apparel/Ring_Mesh";
                type = ItemType.Apparel;
                armour = 1;
                amount = 1;
                break;
            case 202:
                name = "Boots";
                value = 5;
                description = "Not Prada";
                icon = "Apparel/Boots_Icon";
                mesh = "Apparel/Boots_Mesh";
                type = ItemType.Apparel;
                armour = 5;
                amount = 1;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                name = "Spring";
                value = 5;
                description = "Just Junk";
                icon = "Crafting/Spring_Icon";
                mesh = "Crafting/Spring_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            case 301:
                name = "Bomb";
                value = 10;
                description = "Let the world Explode";
                icon = "Crafting/Bomb_Icon";
                mesh = "Crafting/Bomb_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            case 302:
                name = "Gear";
                value = 5;
                description = "Another Junk";
                icon = "Crafting/Gear_Icon";
                mesh = "Crafting/Gear_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            #endregion
            #region Quests 400 - 499

            case 400:
                name = "Eye Ball";
                value = 10;
                description = "Missing Pirate's Eye";
                icon = "Quest/EyeBall_Icon";
                mesh = "Quest/EyeBall_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 401:
                name = "Candle";
                value = 10;
                description = "Use for praying";
                icon = "Quest/Candle_Icon";
                mesh = "Quest/Candle_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 402:
                name = "Key";
                value = 10;
                description = "Unlocking someone house";
                icon = "Quest/Key_Icon";
                mesh = "Quest/Key_Mesh";
                type = ItemType.Quest;
                amount = 1;

                break;
            #endregion
            #region Ingredients 500 - 599
            case 500:
                name = "Herb";
                value = 1;
                description = "Poison Included";
                icon = "Ingredient/Herb_Icon";
                mesh = "Ingredient/Herb_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;
            case 501:
                name = "Flower";
                value = 5;
                description = "Legend says it gives you luck";
                icon = "Ingredient/Flower_Icon";
                mesh = "Ingredient/Flower_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;
            case 502:
                name = "Acorn";
                value = 5;
                description = "Can be used as bullet";
                icon = "Ingredient/Acorn_Icon";
                mesh = "Ingredient/Acorn_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;
            #endregion
            #region Potions 600-699
            case 600:
                name = "Red Potion";
                value = 10;
                description = "Taste like water";
                icon = "Potion/RedPotion_Icon";
                mesh = "Potion/RedPotion_Mesh";
                type = ItemType.Potion;
                heal = 40;
                amount = 1;
                break;
            case 601:
                name = "Blue Potion";
                value = 7;
                description = "Taste like ocean";
                icon = "Potion/BluePotion_Icon";
                mesh = "Potion/BluePotion_Mesh";
                type = ItemType.Potion;
                heal = 30;
                amount = 1;
                break;
            case 602:
                name = "Love Potion";
                value = 15;
                description = "Bug Repellent";
                icon = "Potion/LovePotion_Icon";
                mesh = "Potion/LovePotion_Mesh";
                type = ItemType.Potion;
                heal = 50;
                amount = 1;
                break;

            #endregion
            #region Scrolls 700-799
            case 700:
                name = "Fire Scroll";
                value = 10;
                description = "Create Fire For Cooking";
                icon = "Scroll/FireScroll_Icon";
                mesh = "Scroll/FireScroll_Mesh";
                type = ItemType.Scroll;
                damage = 10;
                amount = 1;
                break;
            case 701:
                name = "Water Scroll";
                value = 10;
                description = "Summon rain for gardening";
                icon = "Scroll/WaterScroll_Icon";
                mesh = "Scroll/WaterScroll_Mesh";
                type = ItemType.Scroll;
                damage = 10;
                amount = 1;
                break;
            case 702:
                name = "Nature Scroll";
                value = 10;
                description = "Instant vegetable for gardening";
                icon = "Scroll/NatureScroll_Icon";
                mesh = "Scroll/NatureScroll_Mesh";
                type = ItemType.Scroll;
                damage = 10;
                amount = 1;
                break;
            #endregion

            default:
                itemID = 0;
                name = "Apple";
                value = 5;
                description = "Yum Yum";
                icon = "Food/Apple_Icon";
                mesh = "Food/Apple_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
        }
        Item temp = new Item
        {
            Name = name,
            Description = description,
            ItemID = itemID,
            Value = value,
            Damage = damage,
            Armour = armour,
            Amount = amount,
            Heal = heal,
            Type = type,
            Mesh = Resources.Load("Prefabs/" + mesh) as GameObject,
            Icon = Resources.Load("Icons/"+icon) as Texture2D
        };
        return temp;
    }

}
