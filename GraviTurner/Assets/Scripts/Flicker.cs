using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {


	public float xMax, xMin, yMax, yMin, delay;

	private float alpha;
	public float flickerAmount;

	private SpriteRenderer sRenderer;
	private UnityEngine.UI.Image img;
	private UnityEngine.UI.Text text;
    private Light lite;
    private float lightLevel;

	// Use this for initialization
	void Start () {
		sRenderer = GetComponent<SpriteRenderer> ();
		img = GetComponent<UnityEngine.UI.Image> ();
		text = GetComponent<UnityEngine.UI.Text> ();
        lite = GetComponent<Light>();
        if (lite != null){
            lightLevel = lite.intensity;
        }
		StartCoroutine (FlameScale ());

	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator FlameScale ()
	{
		while (true) {
			if (sRenderer != null) {
				transform.localScale = new Vector3 (Mathf.Lerp (transform.localScale.x, Random.Range (xMin, xMax), 10 * Time.deltaTime), Mathf.Lerp (transform.localScale.y, Random.Range (yMin, yMax), 10 * Time.deltaTime));
				alpha = Random.Range (1f - flickerAmount, 1f);
				sRenderer.color = new Color (1, 1, 1, alpha);
				yield return new WaitForSeconds (delay);
			}
			if (img != null) {
				//transform.localScale = new Vector3 (Mathf.Lerp (transform.localScale.x, Random.Range (xMin, xMax), 10 * Time.deltaTime), Mathf.Lerp (transform.localScale.y, Random.Range (yMin, yMax), 10 * Time.deltaTime));
				alpha = Random.Range (1f - flickerAmount, 1f);
				img.color = new Color (1, 1, 1, alpha);
				yield return new WaitForSeconds (delay);
			}
			if (text!= null) {
				//transform.localScale = new Vector3 (Mathf.Lerp (transform.localScale.x, Random.Range (xMin, xMax), 10 * Time.deltaTime), Mathf.Lerp (transform.localScale.y, Random.Range (yMin, yMax), 10 * Time.deltaTime));
				alpha = Random.Range (1f - flickerAmount, 1f);
				text.color = new Color (1, 1, 1, alpha);
				yield return new WaitForSeconds (delay);
			}

            if (lite != null)
            {
                alpha = Random.Range(lightLevel - flickerAmount, lightLevel);
                lite.intensity = alpha;
                yield return new WaitForSeconds(delay);
            }
		}
	}
}
