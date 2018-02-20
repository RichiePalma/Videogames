using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.O))
        {
            transform.Rotate(Vector3.right * 50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.P))
        {
            transform.Rotate(-Vector3.right * 50 * Time.deltaTime);
        }
    }
}
