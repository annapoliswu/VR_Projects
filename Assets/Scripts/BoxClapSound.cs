using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClapSound: MonoBehaviour
{
    private AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void PlayThisSoundNow()
    {
        aSource.Play();
    }
}
 