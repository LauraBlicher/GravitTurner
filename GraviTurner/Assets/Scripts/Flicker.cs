using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {


	public float xMax, xMin, yMax, yMin, delay;

	private float alpha;
	public float flickerAmount;

	private SpriteRenderer sRenderer;

	// Use this for initialization
	void Start () {
		sRenderer = GetComponent<SpriteRenderer> ();
		StartCoroutine (FlameScale ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FlameScale ()
	{
		while (true) {
			transform.localScale = new Vector3 (Mathf.Lerp(transform.localScale.x, Random.Range (xMin, xMax), 10 * Time.deltaTime), Mathf.Lerp(transform.localScale.y, Random.Range (yMin, yMax), 10 * Time.deltaTime));
			alpha = Random.Range (1f - flickerAmount, 1f);
			sRenderer.color = new Color (1, 1, 1, alpha);
			yield return new WaitForSeconds(delay);
		}
	}
}
