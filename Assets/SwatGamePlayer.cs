using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwatGamePlayer : MonoBehaviour
{
    Text healthText;
    public int maxHealth = 20;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText = FindObjectOfType<Text>();
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void subHealth()
    {
        if(health > 1)
        {
            health -= 1;
            healthText.text = "Health: " + health;
        }
        else
        {
            //health = maxHealth;
            healthText.text = "Food for the flies..";
        }
    }

}
