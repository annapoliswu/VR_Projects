using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGen3D : MonoBehaviour
{
    public GameObject seedObj;
    public int xDim, yDim, zDim;
    public float seedDist = 1.0f;

    // The grid is generated at startup
    void Start()
    {

        // set up grid values
        Vector3 _curPosition = new Vector3();
        float _xHalf, _yHalf, _zHalf;
        _xHalf = xDim * 0.5f;
        _yHalf = yDim * 0.5f;
        _zHalf = zDim * 0.5f;

        GameObject newObj;
        for (int i = 0; i < yDim; i++)
        {
            for (int j = 0; j < xDim; j++)
            {
                for (int k = 0; k < zDim; k++)
                {
                    _curPosition.x = transform.position.x + (j - _xHalf) * seedDist;
                    _curPosition.y = transform.position.y + (i - _yHalf) * seedDist;
                    _curPosition.z = transform.position.z + (k - _zHalf) * seedDist;

                    Quaternion qrot = Quaternion.Euler(0f, 0f, 0f);
                    newObj = GameObject.Instantiate(seedObj, _curPosition, Quaternion.identity) as GameObject;

                }

            }
        }
        newObj = GameObject.Instantiate(seedObj, _curPosition, Quaternion.identity) as GameObject;
    }
}

