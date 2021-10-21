using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
                new Item(0, "Diamond Sword", "A sword", "pick_diamond"),
                new Item(1, "Gold Ore", "A shiny valuable rock", "ore_gold"),
                new Item(2, "Cheese Block", "A block of cheese", "block_cheese")
        };
    }


    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

 

}
