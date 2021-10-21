using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public PickItem item;
    private Image spriteImage;
    public string itemName = "";

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);   // items empty on awake
    }

    public void UpdateItem(PickItem pickup)
    {
        item = pickup;
        if(item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;
            //spriteImage.sprite = Resources.Load<Sprite>("Sprites/Items/block_cheese");
            Debug.Log("Updated item ui");
        }
        else
        {
            spriteImage.color = Color.clear; //if no item, hide 
             Debug.Log("item was null for ui");
        }
    }

}
