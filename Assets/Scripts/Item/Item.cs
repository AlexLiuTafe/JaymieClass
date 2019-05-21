//in this script  you will only need using UnityEngine as we just need the script to connect to unity
using UnityEngine;
//this public class doent inherit from MonoBehaviour
//this script is also referenced by other scripts but never attached to anything
public class Item
{
    //basic variables for items that we need are 
    #region Private Variables
    //Identification Number
    private int _itemID;
    //Object Name
    private string _name;
    //Value of the Object
    public int _value;
    //Description of what the Object is
    private string _description;
    //Icon that displays when that Object is in an Inventory
    private Texture2D _icon;
    //Mesh of that object when it is equipt or in the world
    private GameObject _mesh;
    //Enum ItemType which is the Type of object so we can classify them
    private ItemType _type;
    private int _heal;
    private int _damage;
    private int _armour;
    private int _amount;
    #endregion

    #region Public Variables
    //here we are creating the public versions or our private variables that we can reference and connect to when interacting with items
    public int ItemID //public Identification Number 
    {
        //get the private Identification Number
        get { return _itemID; }
        //and set it to the value of our public Identification Number
        set { _itemID = value; }
    }
    public string Name//public Name
    {
        //get the private Name
        get { return _name; }
        //and set it to the value of our public Name
        set { _name = value; }
    }

    public int Value//public Value 
    {
        //get the private Value
        get { return _value; }
        //and set it to the value of our public Value
        set { _value = value; }
    }
    public string Description//public Description 
    {
        //get the private Description
        get { return _description; }
        //and set it to the value of our public Description
        set { _description = value; }
    }
    public Texture2D Icon//public Icon 
    {
        //get the private Icon
        get { return _icon; }
        //and set it to the value of our public Icon
        set { _icon = value; }
    }
    public GameObject Mesh//public Mesh 
    {
        //get the private Mesh
        get { return _mesh; }
        //and set it to the value of our public Mesh
        set { _mesh = value; }
    }
    public ItemType Type //public Type 
    {
        //get the private Type
        get { return _type; }
        //and set it to the value of our public Type
        set { _type = value; }
    }
    public int Damage 
        {
        get { return _damage; }
        set { _damage = value; }
        }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    #endregion
}
#region Enums
//The Global Enum ItemType that we have created categories in
public enum ItemType
{
    Food,
    Weapon,
    Apparel,
    Crafting,
    Quest,
    Money,
    Ingredient,
    Potion,
    Scroll
}
#endregion
