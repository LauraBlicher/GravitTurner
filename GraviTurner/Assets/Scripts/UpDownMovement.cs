using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement: MonoBehaviour {

    public float delta = 1.5f;
    public float speed = 2.0f;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {

        startPos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;

        }
}
