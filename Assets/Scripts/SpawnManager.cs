using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;

    public float spawnRadius = 5;
    public int spawnInterval = 2;
    public int speed = 2;

    public GameObject target;
    public List<GameObject> prefabs = new List<GameObject>();
    private List<GameObject> objList = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }


        // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnObj", 0, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject bug in objList)
        {
            float step = speed * Time.deltaTime;
            
            bug.transform.position = Vector3.MoveTowards(bug.transform.position, target.transform.position, step);
            //bug.transform.position = Vector3.MoveTowards(bug.transform.position, bug.transform.position + r, 20 * Time.deltaTime);
        }
    }

    private void SpawnObj()
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 startPosition = new Vector3(0,0,0);
        Vector2 rand2D = Random.insideUnitCircle * spawnRadius;

        startPosition.x = rand2D.x;
        startPosition.z = rand2D.y;
        startPosition.y = 5;

        

        GameObject objToAdd = GameObject.Instantiate(prefabs[0], this.transform.position , Quaternion.identity);
        

        objList.Add(objToAdd);

    }

    private IEnumerator DropObj(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);
        obj.GetComponent<Rigidbody>().useGravity = true;
    }

    private void DespawnObj()
    {   
        //can play a despawn anim here if want
        GameObject objToDestroy = objList[0];
        objList.RemoveAt(0);
        Destroy(objToDestroy);
    }

    private void DespawnObj(int listPosn)
    {
        GameObject objToDestroy = objList[listPosn];
        objList.RemoveAt(listPosn);
        Destroy(objToDestroy);
    }

    /**
    private void bugDodge()
    {
        foreach (GameObject bug in objList)
        {
            Vector3 r = Random.insideUnitCircle * 10;
            bug.transform.position = Vector3.MoveTowards(bug.transform.position, bug.transform.position + r, 20 * Time.deltaTime);
        }
    }
    **/

}
