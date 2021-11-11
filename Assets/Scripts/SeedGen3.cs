using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGen3 : MonoBehaviour
{
    public GameObject[] parts;
    public float[] rotations;
    public Material[] materials;
    public float scaleMin = 1.0f, scaleMax = 1.1f;
    private Renderer rend;

    // Start is used to set determine the element
    void Start()
    {
        // first choose a model from the supplied array
        GameObject newObj;
        int objIndex = Random.Range(0, parts.Length);

        // set the rotations from the supplied array
        Quaternion qrot = Quaternion.Euler(rotations[Random.Range(0, rotations.Length)], rotations[Random.Range(0, rotations.Length)], 0f);

        // instantiate the new game object
        newObj = GameObject.Instantiate(parts[objIndex], transform.position, qrot) as GameObject;

        // set the scale randomly between min and max
        float newScale = Random.Range(scaleMin, scaleMax);
        newObj.transform.localScale = new Vector3(newScale, newScale, newScale);

        // Fetch the Renderer from the new GameObject
        rend = newObj.GetComponent<Renderer>();

        // choose the material from the array provided
        int matIndex = Random.Range(0, materials.Length);
        rend.material = materials[matIndex];

        // Set the texture scale and offset
        rend.material.SetTextureOffset("_BaseMap", new Vector2(0.2f, 0.7f));
        float scale = Random.Range(0.1f, 1.0f);
        rend.material.SetTextureScale("_BaseMap", new Vector2(scale, scale));
    }

}


