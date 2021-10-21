using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessData : MonoBehaviour
{
    public ScriptObj mainData;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("from scriptable object " + mainData.someNum);
        if (mainData.words.Length > 2)
        {
            Debug.Log("from scriptable object " + mainData.words[1]);
            mainData.words[1] = "goodbye"; // these runtime changes will persist!
        }


    }


}
