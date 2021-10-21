using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeTrigger : MonoBehaviour
{

    public Animator anim;
    public Animator dawnAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            anim.SetBool("open", true);
            dawnAnim.SetBool("dawnYes", true);
        }
    }
}
