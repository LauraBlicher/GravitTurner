using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {


	public UnityEngine.UI.Button winButton;
	public UnityEngine.UI.Text winText;
	public UnityEngine.UI.Image buttonImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			winButton.enabled = true;
			winText.enabled = true;
			buttonImage.enabled = true;
			}
	}
}
