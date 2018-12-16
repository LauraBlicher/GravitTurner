using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static bool isDead; 
    private bool isAirborne;
    private Rigidbody rb;
    public float movementSpeed = 5f, jumpForce = 5f;
    private GameObject visual;
    private Animator anim;

    	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        isDead = false;
        visual = transform.Find("Visual").gameObject;
        anim = visual.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movementSpeed*Time.deltaTime, 0, 0));
        }
        if (!isAirborne)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddRelativeForce(new Vector3(0, jumpForce, 0),ForceMode.Impulse);
                isAirborne = true;
                anim.SetTrigger("Jumping");
                anim.ResetTrigger("Landed");
            }
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            visual.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            visual.GetComponent<SpriteRenderer>().flipX = false;
        }
        anim.SetFloat("upwardsMomentum", transform.InverseTransformDirection(rb.velocity).y);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isAirborne = false;
            anim.SetTrigger("Landed");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Spikes")
        {
            isDead = true;
            Debug.Log("died");
            anim.SetBool("isHit", true);

        }
    }
        

}
