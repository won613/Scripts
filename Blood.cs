using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {
    private Animator myAnim;
    // Use this for initialization
    void Start () {
        myAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.myAnim.GetCurrentAnimatorStateInfo(0).IsName("Blood"))
        {
            //Destroy(gameObject);
        }
    }

    
}
