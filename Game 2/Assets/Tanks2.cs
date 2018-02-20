using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanks2 : MonoBehaviour {
    public GameObject originalBullet;
    public Transform punta;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) 
                || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(v * Time.deltaTime * 5, 0, (-1) * h * Time.deltaTime * 5);
        }
        if (Input.GetKeyUp(KeyCode.L))
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
