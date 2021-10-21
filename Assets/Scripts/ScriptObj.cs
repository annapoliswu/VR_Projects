using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// example of scriptable object for data
[CreateAssetMenu(menuName = "scriptObj")]
public class ScriptObj : ScriptableObject
{
    public int someNum = 5;
    public string[] words;
}
