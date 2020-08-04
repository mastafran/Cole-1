using UnityEngine;
using System.Collections;

public enum ItemType {
    Weapon,
    Spell,
    Key,
    Use,
    Special
}

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public string itemInfo;
    public Texture2D itemIcon;
    public int itemPower;
    public float itemSpeed;
    public int itemCost;
    public ItemType itemType;

    public Item() {
    }

    public Item(string name, int id, string info, int power, float speed, int cost, ItemType type) {
        itemName = name;
        itemID = id;
        itemInfo = info;
        //itemIcon = "";
        itemPower = power;
        itemSpeed = speed;
        itemCost = cost;
        itemType = type;
    }
}
