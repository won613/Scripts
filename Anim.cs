using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour {

    private Animator myAnim;

    public bool isGrounded;
    // Use this for initialization
    void Start () {
        myAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);
    }
}
