using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // retrieving a reference to a component
    private Rigidbody rb;
	// Use this for initialization
	void Start () {

        //this can always return null
        rb = GetComponent<Rigidbody>();

        // -20
        rb.AddForce(100*transform.up, ForceMode.Impulse);
        Destroy(gameObject, 3); //3 = seconds
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
