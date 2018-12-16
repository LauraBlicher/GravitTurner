using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerScript : MonoBehaviour {

    public static GameObject player;
    public GameObject newPlayer;
    public Transform respawn;
    private bool readyToRespawn;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag("Respawn").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerController.isDead)
        {
            StartCoroutine(PlayerDeath());
        }

        if (readyToRespawn)
        {
            if (Input.GetButtonDown("Respawn"))
            {
              player = Instantiate(newPlayer, respawn.position, respawn.rotation);
              readyToRespawn = false;
            }
        }
	}
    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(1f);
        PlayerController.isDead = false;
        Destroy(player);
        readyToRespawn = true;

    }
}
