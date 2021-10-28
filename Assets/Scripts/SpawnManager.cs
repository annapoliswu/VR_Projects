using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;

    public int spawnInterval = 2;
    public float bugMaxSpeed = 4f;
    public float bugMaxHeight = 2f;
    public int bugMaxWaitTime = 3;

    public GameObject target;
    public List<GameObject> prefabs = new List<GameObject>();
    private List<GameObject> bugs = new List<GameObject>();


    private void Awake()
    {
       

    }


        // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnObj", 0, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject bug in bugs) //update
        {
            if (bug != null)
            {
                //if within target radius delete
                float distance = Vector3.Distance(target.transform.position, bug.transform.position);

                bug.GetComponent<Bug>().Move();
            }
        }

        bugs.RemoveAll(bug => bug == null);


    }

    private void SpawnObj()
    {
        GameObject obj = GameObject.Instantiate(prefabs[0], this.transform.position , Quaternion.identity);
        Bug bugData = obj.AddComponent<Bug>();

        bugData.gameobj = obj;
        bugData.speed = Random.Range(1.5f, bugMaxSpeed);
        bugData.height = Random.Range(1f, bugMaxHeight);
        bugData.waitTime = Random.Range(1, bugMaxWaitTime);
        bugData.coroutine = StartCoroutine(OscBug(bugData));
        bugData.target = target;

        bugs.Add(obj);

    }






    IEnumerator OscBug(Bug bug)
    {
        while (true && bug.gameobj != null)
        {
            yield return new WaitForSeconds(bug.waitTime);
            print("Waited for: " + bug.waitTime);
            if (bug.direction == Bug.Direction.Up)
            {
                bug.direction = Bug.Direction.Down;
            }
            else if (bug.direction == Bug.Direction.Down)
            {
                bug.direction = Bug.Direction.Up;
            }
        }
    }


}
