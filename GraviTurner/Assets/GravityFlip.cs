using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour {

    //public GameObject cam;
    public enum Directions { Up, Down, Left, Right};
    public Directions dir = Directions.Down;
    private bool isTurning;
    public float speed = 1f;


	// Use this for initialization
	void Start () {

       // cam = GameObject.FindGameObjectWithTag("MainCamera");
        Physics.gravity= new Vector3(0, -9.81f, 0);

    }
	
	// Update is called once per frame
	void Update () {
              
        if (!isTurning)
        {
            if (Input.GetKeyDown("q"))
            {
                switch (dir)
                {
                    case Directions.Up:
                        dir = Directions.Right;
                        break;
                    case Directions.Down:
                        dir = Directions.Left;
                        break;
                    case Directions.Left:
                        dir = Directions.Up;
                        break;
                    case Directions.Right:
                        dir = Directions.Down;
                        break;
                }
                StartCoroutine(TurnLeft());
            }
            if (Input.GetKeyDown("e"))
            {
                switch (dir)
                {
                    case Directions.Up:
                        dir = Directions.Left;
                        break;
                    case Directions.Down:
                        dir = Directions.Right;
                        break;
                    case Directions.Left:
                        dir = Directions.Down;
                        break;
                    case Directions.Right:
                        dir = Directions.Up;
                        break;
                }
                StartCoroutine(TurnRight());
            }

        }
    }
    IEnumerator TurnLeft()
    {
        isTurning = true;
         
        switch (dir)
        {
            case Directions.Up:
                Physics.gravity = new Vector3(0, 9.81f, 0);
                break;
            case Directions.Down:
                Physics.gravity = new Vector3(0, -9.81f, 0);
                break;
            case Directions.Left:
                Physics.gravity = new Vector3(-9.81f, 0, 0);
                break;
            case Directions.Right:
                Physics.gravity = new Vector3(9.81f, 0, 0);
                break;
        }
    
        for (float i = 0; i < 90; i=i+speed)
        {
            transform.Rotate(new Vector3(0, 0, speed*-1f));
          //  cam.transform.Rotate(new Vector3(0, 0, speed * -1f));
            if (transform.eulerAngles.z <= -179f)
            {
                transform.rotation = new Quaternion(0, 0, 1f, 0);
                //cam.transform.rotation = new Quaternion(0, 0, 1f, 0);
            }
                yield return null;
        }

        isTurning = false;
    }
    IEnumerator TurnRight()
    {
        isTurning = true;

        switch (dir)
        {
            case Directions.Up:
                Physics.gravity = new Vector3(0, 9.81f, 0);
                break;
            case Directions.Down:
                Physics.gravity = new Vector3(0, -9.81f, 0);
                break;
            case Directions.Left:
                Physics.gravity = new Vector3(-9.81f, 0, 0);
                break;
            case Directions.Right:
                Physics.gravity = new Vector3(9.81f, 0, 0);
                break;
        }

        for (float i = 0; i < 90; i = i + speed)
        {
            transform.Rotate(new Vector3(0, 0, speed));
            //cam.transform.Rotate(new Vector3(0, 0, speed));
            if (transform.eulerAngles.z <= -179f)
            {
                transform.rotation = new Quaternion(0, 0, 1f, 0);
                //cam.transform.rotation = new Quaternion(0, 0, 1f, 0);
            }
            yield return null;
        }

        isTurning = false;
    }

}
