//namespaces - libreria
// .NET 2.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cubo : MonoBehaviour
{ //The : means inheritance

    // reference to other components
    // all components have a corresponding class
    private Transform t;

    // attributos publicos
    // primitivos y clases de unity pueden ser modificadas desde editor
    public float velocidad;

    public GameObject go;
    public Text text;

    private Vector3 pos;
    // Use this for initialization
    void Start()
    {

        // this can return null!!! (when you have no component of that type)
        // whenever you do this do it the least times possible since it is expensive
        t = GetComponent<Transform>();
        go = GameObject.Find("Score");
        text = go.GetComponent<Text>();
        text.text = "Score: "+Enemies.score;
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //you can also do t.Translate (0.01f, 0, 0);
        // first issue is speed in frames since slow computers run the game slower than fast ones
        // Time.deltaTime it keeps track of how much time passed since last frame
        // Debug.Log(Time.deltaTime);
        //Debug.Log(Time.deltaTime); can also print or print();

        //input - 2 ways to catch input
        // - directly pole(consultar) from device
        if (Input.GetKeyDown(KeyCode.A))
        { //Only prints when A is pressed
            print("Key Down");
        }

        if (Input.GetKey(KeyCode.A))
        { //While A is pressed 
            print("Just Key");
        }

        if (Input.GetKeyUp(KeyCode.A)) //Key released
        {
            print("Key Released");
        }

        if (Input.GetMouseButtonDown(0))
        { //0 is left click
            print(Input.mousePosition);
        }
        // - through axes (plural of axis)

        //float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //print(h);
        transform.Translate(0, v * velocidad * Time.deltaTime, 0, Space.World);
        //Space.World es para que los ejes no se volteen cuando colisione la figura
    }

    void OnCollisionEnter(Collision c) //En cuanto sucede
    {

        print(c.gameObject.transform.name); //c.gameObject es referencia al objeto con quien chocas
        Enemies.score = Enemies.score;
    }

    void OnCollisionStay(Collision c)  //Mientras sucede
    {

    }

    void OnTriggerEnter(Collider c) //Cuando deja de suceder
    {
       // Destroy(c.gameObject); //Destruye el objeto con el que choco
        transform.position = pos;
    }

    void OnTriggerStay(Collider c)
    {

    }

    void OnTriggerExit(Collider c)
    {

    }

}

