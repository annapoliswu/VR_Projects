using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugInteraction : MonoBehaviour
{
    AudioManager audioManager;
    SwatGamePlayer player;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        player = FindObjectOfType<SwatGamePlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            print("in target, trigger");

            audioManager.Play("Munch");
            Destroy(gameObject);
            player.subHealth();
        }
        else if (other.gameObject.CompareTag("Grabbable"))
        {
            print("in swatter");

            Destroy(gameObject);
            audioManager.Play("Slap");
        }
    }
}
