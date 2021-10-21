using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public Transform slotPanel;
    public GameObject slotPrefab;

    public int numberOfSlots = 6;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);              //create prefab
            instance.transform.SetParent(slotPanel);            
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }


    public void UpdateSlot(int slot, PickItem item)
    {
        uiItems[slot].UpdateItem(item);
    }

    //find slot with no item and add
    public void AddNewItem(PickItem item)
    {
        Debug.Log("index: " + uiItems.FindIndex(i => i.item == null));
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(PickItem item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }


}
