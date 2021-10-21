using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<PickItem> myItems = new List<PickItem>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;
    private AudioManager audioManager;


    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("Collision entered");
        GameObject obj = collision.gameObject;
        PickItem itemHit = obj.GetComponent<PickItem>();
        if(itemHit != null && myItems.Count < inventoryUI.numberOfSlots){
            AddItem(itemHit);
            itemHit.Pickup();
            audioManager.Play("ItemPickup");
        }else{
            Debug.Log("Inv Full or is not item");
        }
    }




    public void AddItem(PickItem itemToAdd)
    {
        myItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added: " + itemToAdd.title);
    }


    public void RemoveItem(PickItem item)
    {
        myItems.Remove(item);
        inventoryUI.RemoveItem(item);
        Debug.Log("Item removed: " + item.title);
    }

}
