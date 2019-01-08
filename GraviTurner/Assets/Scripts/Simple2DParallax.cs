using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple2DParallax : MonoBehaviour {

	public GameObject referenceObject;
	public float parallaxFactor = 0.5f;

	private Vector3 globalZero;
	private float zDepth;

	// Use this for initialization
	void Start () {
		if (referenceObject == null) {
			referenceObject = Camera.main.gameObject;
		}
		globalZero = Vector3.zero; //new Vector3(100,0,0);
		zDepth = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = referenceObject.transform.position - globalZero;
		newPos.z = zDepth;
		newPos *= parallaxFactor;
		transform.position = newPos;
	}
}
