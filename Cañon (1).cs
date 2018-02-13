using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour {

    public GameObject originalBullet;
    public Transform punta;
	// Use this for initialization
	void Start () {
        StartCoroutine(EjemplodeCorutina());
	}

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, h * Time.deltaTime * 5);

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

    // coroutine - NO es concurrencia (pero parece!)
    // pseudohilos
    IEnumerator EjemplodeCorutina()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f); //Yield = ceder
            Instantiate(originalBullet, punta.position, transform.rotation);
            print("hola");
        }

    }
}
