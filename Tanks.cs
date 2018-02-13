using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanks : MonoBehaviour {
    public GameObject originalBullet;
    public Transform punta;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            transform.Translate((-1) * v * Time.deltaTime * 5, 0, h * Time.deltaTime * 5);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //do the shooting
            //Instantiate - clone an object
            //We need a reference to the original
            // Instantiate(originalBullet);
            // rotation - Quaternion - vector de 4 valores, expresa rotacion en un espacio 3D
            Instantiate(originalBullet, punta.position, transform.rotation);
        }

    }
}
