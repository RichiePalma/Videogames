using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        Invoke("Explotar", 2);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void Explotar()
    {
        rb.AddExplosionForce(2000, Vector3.zero, 10);
        print("si jala");
    }
}
