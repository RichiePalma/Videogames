using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Node[] path;
    public float threshold;

    private int currentNode;
	// Use this for initialization
	void Start () {
        currentNode = 0;
        StartCoroutine(HacerCambio());
	}
	
	// Update is called once per frame
	void Update () {
        //Solo input y movimiento dentro de update
        //rota el objeto de tal manera que el frende de este objeto ve al objetico
        transform.LookAt(path[currentNode].transform);
        transform.Translate(transform.forward*Time.deltaTime*5, Space.World);
	}

    IEnumerator HacerCambio()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            float distancia = Vector3.Distance(transform.position, path[currentNode].transform.position);
            if(distancia < threshold) {
                currentNode++;
                currentNode %= path.Length;
             }
        }
    }
}
