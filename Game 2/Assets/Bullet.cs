using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        // -20
        rb.AddForce(125 * transform.forward, ForceMode.Impulse);
        rb.AddForce(150 * transform.up, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c) //Cuando deja de suceder
    {
        Destroy(c.gameObject); //Destruye el objeto con el que choco
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
