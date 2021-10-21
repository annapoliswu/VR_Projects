using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    
    public int id;
    public string title;
    public string description;
    public Sprite icon;

    public Item(int id, string title, string desc, Sprite icon)
    {
        this.id = id;
        this.title = title;
        this.description = desc;
        this.icon = icon;
    }

    public Item(int id, string title, string desc, string fileName)
    {
        this.id = id;
        this.title = title;
        this.description = desc;
        this.icon = Resources.Load<Sprite>("Items/Sprites/" + fileName);
    }
}
