using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public Sprite icon;
    public string title = ""; 
    public string description = "";
    public bool picked = false;

 
    public void Pickup()
    {
        picked = true;
        this.gameObject.SetActive(false);
        //don't destroy, otherwise list refs to item gone
    }
}
