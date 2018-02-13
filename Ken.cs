using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken : MonoBehaviour {
    private Animator a;
    private float jAnterior;
    public GameObject hadouken;
    public Transform referencia;
	// Use this for initialization
	void Start () {
        a = GetComponent<Animator>();
        jAnterior = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(h * Time.deltaTime * 5, 0, 0);
        a.SetFloat("speed", h);
        float j = Input.GetAxis("Jump");
        if(jAnterior == 0 && j == 1)
        {
            a.SetTrigger("hadouken");
        }
        jAnterior = j;
	}

    public void Hadouken()
    {
        Instantiate(hadouken, referencia.position, hadouken.transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
