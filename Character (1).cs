using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    Vector3 newPosition;
    // Use this for initialization
    GameObject persona;
    void Start () {
        newPosition = transform.position;
        persona = GameObject.Find("Character");
    }
	
	// Update is called once per frame
	void Update () {
        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h * 10 * Time.deltaTime, v * 10 * Time.deltaTime, 0, Space.World);*/

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                persona.transform.position = hit.point;
                
            }
        }
    }
}
