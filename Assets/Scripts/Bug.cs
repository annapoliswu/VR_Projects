using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right };
    public Direction direction;

    public GameObject gameobj;
    public GameObject target;
    public float speed;
    public float height;
    public int waitTime;
    public Coroutine coroutine; //hold onto to stop later

    private Vector3 upPosn;
    private Vector3 downPosn;

    //probably better to add to prefab obj as script, than save prefab here??
    public Bug(GameObject t, GameObject g, float s, float h, int wt)
    {
        target = t;
        gameobj = g;
        speed = s;
        height = h;
        waitTime = wt;
        direction = Direction.Up;



    }

    public void Move() //called on every update
    {

        float step = speed * Time.deltaTime;
        Vector3 newTargetPosn = new Vector3();


        if (Vector3.Distance(target.transform.position, this.transform.position) > 2) //if within target go straight to target
        {
            if (direction == Direction.Up)
            {
                newTargetPosn = upPosn;
            }
            else if (direction == Direction.Down)
            {
                newTargetPosn = downPosn;
            }
        }
        else
        {
            newTargetPosn = target.transform.position;
        }

        //this.gameobj.transform.position = Vector3.MoveTowards(this.gameobj.transform.position, newTargetPosn, step);
        Vector3 v = Vector3.MoveTowards(this.transform.position, newTargetPosn, step);
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.transform.position = v;
        rigidbody.transform.LookAt(target.transform);

    }


    // Start is called before the first frame update
    void Start()
    {
        upPosn = target.transform.position;
        upPosn.y += height;

        downPosn = target.transform.position;
        downPosn.y -= height;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        StopCoroutine(coroutine);
    }
}
