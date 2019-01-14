using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    float dirX;
    public float moveSpeed = 3f;
    bool moveRight = true;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 4f)
            moveRight = false;
        if (transform.position.x < -4f)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }


}