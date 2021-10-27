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
    private List<Bug> bugs = new List<Bug>();
    private List<Bug> bugsToDelete = new List<Bug>();

    private float targetRadius = .5f;

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
        foreach(Bug bug in bugs) //update
        {
            //if within target radius delete
            float distance = Vector3.Distance(target.transform.position, bug.gameobj.transform.position);
            if (distance < targetRadius)
            {
                RemoveBug(bug);
            }

            //float step = speed * Time.deltaTime;

            //bug.gameobj.transform.position = Vector3.MoveTowards(bug.gameobj.transform.position, target.transform.position, step);
            //bug.gameobj.transform.position = Vector3.MoveTowards(bug.gameobj.transform.position, bug.gameobj.transform.position + r, 20 * Time.deltaTime);
            bug.Move();
        }

        if (bugsToDelete != null)
        {
            foreach (Bug bug in bugsToDelete)
            {
                bugs.RemoveAt(bugs.IndexOf(bug));
                StopCoroutine(bug.coroutine);
                Destroy(bug.gameobj);
            }
            bugsToDelete.Clear();
        }
    }

    private void SpawnObj()
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 startPosition = new Vector3(0,0,0);
        Vector2 rand2D = Random.insideUnitCircle * spawnRadius;
        

        GameObject obj = GameObject.Instantiate(prefabs[0], this.transform.position , Quaternion.identity);

        float speed = Random.Range(1.5f, 3f);
        float height = 5;
        int waitTime = Random.Range(1, 3);
        Bug bugToAdd = new Bug(target, obj, speed, height, waitTime);
        bugToAdd.coroutine = StartCoroutine(OscBug(bugToAdd));

        bugs.Add(bugToAdd);

    }



    public void RemoveBug(Bug bug)
    {
        bugsToDelete.Add(bug);
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

public class Bug{

    public enum Direction { Up, Down, Left, Right };
    public Direction direction;

    public GameObject gameobj;
    public GameObject target;
    public float speed;
    public float height;
    public int waitTime;
    public Coroutine coroutine;

    private Vector3 upPosn;
    private Vector3 downPosn;

    public Bug(GameObject t, GameObject g, float s, float h, int wt)
    {
        target = t;
        gameobj = g;
        speed = s;
        height = h;
        waitTime = wt;
        direction = Direction.Up;

        upPosn = target.transform.position;
        upPosn.y += height;

        downPosn = target.transform.position;
        downPosn.y -= height;

    }

    public void Move() //called on every update
    {

        float step = speed * Time.deltaTime;
        Vector3 newTargetPosn = new Vector3();


        if (Vector3.Distance(target.transform.position, gameobj.transform.position) > 2) //if within target go straight to target
        {
            if(direction == Direction.Up)
            {
                newTargetPosn = upPosn;
            }else if(direction == Direction.Down)
            {
                newTargetPosn = downPosn;
            }
        }
        else
        {
            newTargetPosn = target.transform.position;
        }

        this.gameobj.transform.position = Vector3.MoveTowards(this.gameobj.transform.position, newTargetPosn, step);


    }



    
}
