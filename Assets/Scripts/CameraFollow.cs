using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //get camera offset
        offset = this.transform.position - character.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = character.position + offset;
        this.transform.rotation = character.rotation;
    }
}
