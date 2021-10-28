using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugInteraction : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            print("in target, trigger");
            Destroy(gameObject);

        }
        else if (other.gameObject.CompareTag("Grabbable"))
        {
            print("in swatter");

            Destroy(gameObject);
            audioManager.Play("Slap");
        }
    }
}
