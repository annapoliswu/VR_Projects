using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugInteraction : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            print("in target");
            Destroy(gameObject);

        }else if (collision.gameObject.CompareTag("Swatter")){

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            print("in target, trigger");
            Destroy(gameObject);

        }
        else if (other.gameObject.CompareTag("Swatter"))
        {

            Destroy(gameObject);
        }
    }
}
