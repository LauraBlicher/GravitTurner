using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnCollect : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
