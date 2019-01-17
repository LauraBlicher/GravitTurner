using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCrystalScript : MonoBehaviour {

    public bool hasHammer;

    public UnityEngine.UI.Button winButton;
    public UnityEngine.UI.Text winText;
    public UnityEngine.UI.Image buttonImage;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Crystal")
        {
            if (hasHammer)
            {
                winButton.enabled = true;
                winText.enabled = true;
                buttonImage.enabled = true;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hammer")
        {
            hasHammer = true;
            Destroy(other.gameObject);
        }
    }

}
