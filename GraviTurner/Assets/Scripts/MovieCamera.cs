using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovieCamera : MonoBehaviour {

    public float speed;
    private float defaultSpeed;

    void Awake()
    {
        defaultSpeed = speed;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * speed * Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        MovieCameraSpeedZone zone = other.GetComponent<MovieCameraSpeedZone>();

        if (zone != null)
        {
            speed = zone.cameraSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        MovieCameraSpeedZone zone = other.GetComponent<MovieCameraSpeedZone>();

        if (zone != null)
        {
            speed = defaultSpeed;
        }
    }
}
