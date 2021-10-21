using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dawnReset : MonoBehaviour
{
   private Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("resetting animation1");
        myAnim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Reset()
    {
        //Debug.Log("resetting animation2");
        myAnim.SetBool("dawnYes", false);
    }

}

