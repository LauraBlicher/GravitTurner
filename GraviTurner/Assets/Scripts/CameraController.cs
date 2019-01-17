using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float dist;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (EventManagerScript.player != null)
        {
            dist = Vector3.Distance(transform.position, EventManagerScript.player.transform.position);
            GetComponent<Camera>().orthographicSize = dist - 5f;
            transform.position = Vector3.Lerp(transform.position, new Vector3(EventManagerScript.player.transform.position.x, EventManagerScript.player.transform.position.y, -10f), Time.deltaTime);
            transform.rotation = EventManagerScript.player.transform.rotation;
        }
    }
}
