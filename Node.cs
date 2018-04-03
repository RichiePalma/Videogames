using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Node[] children;
    public List<Node> historial;
    public float g, h;
    // Use this for initialization

//properties - C#
    public float F
    {
        get
        {
            return g + h;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        // sirve para dibujar Gizmos
        //gizmos - graficos de ayuda para desarollador (icono camarita etc...)
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);

        if (children != null && children.Length > 0)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < children.Length; i++)
            {
                Gizmos.DrawLine(transform.position, children[i].transform.position);
            }
        }
    }
}
