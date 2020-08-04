using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public List<Item> inventory = new List<Item>();
    [SerializeField]
    private ItemDatabase itemDatabase;
    private int itemCount;

    void Start() {
        
        for(int i = 0; i<itemDatabase.items.Count; i++) {
            inventory.Add(itemDatabase.items[i]);
        }
    }

    void OnGUI() {
        for(int i = 0; i < inventory.Count; i++) {
            GUI.Label(new Rect(10,i*32,200,50), inventory[i].itemName);
        }
    }

}
