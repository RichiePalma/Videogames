using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject projectile;
    IEnumerator corutina;
    private float jAnterior;
	// Use this for initialization
	void Start () {
        //StartCoroutine(Ejemplo1());
        corutina = Ejemplo1();
        jAnterior = 0;
	}
	
	// Update is called once per frame
    // pseudothreads
    // -similar to concurrency
	void Update () {
        float j = Input.GetAxisRaw("Jump");
        if(jAnterior == 0 && j == 1)
        {
            StartCoroutine(corutina);
        }
        if(jAnterior ==1 && j == 0)
        {
            // StopCoroutine(corutina);
            StopAllCoroutines();
        }
        jAnterior = j;
	}
    IEnumerator Ejemplo1()
    {
           //use as many as needed (little overhead)
        while (true)
        {
            //always have a wait of some sort
            yield return new WaitForSeconds(0.2f);
            print("hola");
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
