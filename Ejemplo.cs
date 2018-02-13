using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour {
    // La lógica en el engine se ejecuta como un loop

    // La logica entra en piezas en puntos especificos(eventos)
    // ciclo de vida - tiene diferentes metodos

    //Se ejecuta una vez al iniciar el gameobject
    void Awake() {

        //ojo - no sabemos el orden de ejecución de awake en gameobjects
        print("Awake");
    }
    
    // Se ejecutra una vez espues de TODOS los awake
    // Use this for initialization
    void Start () {
        print("Start");
	}
	
	// Se ejecuta una vez por frame
    // Frames - fps
    // fps idealmente máximo posible (60 para arriba)
    //lomite inferior para considerarlo una aplicacion en tiempo real 30fps
    // Update is called once per frame
	void Update () {

        // Se ejecuta una vez por frame(cuadro)
        //idealmente se encarga de 2 operaciones
        // - entrada de usuario
        // - movimiento
        print("Update");
	}

   void LateUpdate(){
        print("Late Update");
        
    }
    // corre en un framerate fijo(fixed)
    void FixedUpdate(){
        print("Fixed Update");
    }
}
