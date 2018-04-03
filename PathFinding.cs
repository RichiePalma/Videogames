using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

    // 3 Algorithms 

    //First two are uninformed (desinformados)
    //Unica garantia para regresar una ruta si existe 
    //No necesariamente buena ni la mejor
    public static List<Node> Breadthwise(Node start, Node end) //Root luego sus hijos, luego hijos de sus hijos
                                                               //luego hijos de los hijos de los hijos, busca por nivel de izq a derecha
    {
        List<Node> visited = new List<Node>();
        Queue<Node> working = new Queue<Node>();
        

        visited.Add(start);
        working.Enqueue(start);
        start.historial = new List<Node>();

        while (working.Count > 0)
        {
            Node current = working.Dequeue();
            if (current == end)
            {
                List<Node> resultado = end.historial;
                resultado.Add(end);
                return resultado;
            }
            else
            {
                //si no fue este, seguir buscando
                for (int i = 0; i < current.children.Length; i++)
                {
                    //procesar cada hijo
                    Node currentChild = current.children[i];
                    if (!visited.Contains(currentChild))
                    {
                        visited.Add(currentChild);
                        working.Enqueue(currentChild);
                        currentChild.historial = new List<Node>(current.historial); //Agregas historial del padre
                        currentChild.historial.Add(current); //Agregas al padre
                    }
                }
            }
        }
        return null;
    }

    public static List<Node> Depthwise(Node start, Node end) //Mejor cuando pocos vecinos y el final esta lejos
    {
        List<Node> visited = new List<Node>();
        Stack<Node> working = new Stack<Node>();

        visited.Add(start);
        working.Push(start);
        start.historial = new List<Node>();

        while (working.Count > 0)
        {
            Node current = working.Pop();
            if (current == end)
            {
                List<Node> resultado = current.historial;
                resultado.Add(current);
                return resultado;
            }
            else
            {
                for (int i = 0; i < current.children.Length; i++)
                {
                    Node currentChild = current.children[i];
                    if (!visited.Contains(currentChild))
                    {
                        visited.Add(currentChild);
                        working.Push(currentChild);
                        currentChild.historial = new List<Node>(current.historial);
                        currentChild.historial.Add(current);
                    }
                }
            }

        }
        return null;
    }
    // Informed algorithm
    // Utiliza información para su criterio de busqueda
    // Garantia: buena ruta pero no necesariamente la mejor
    public static List<Node> AStar(Node start, Node end)
    {
        List<Node> visited = new List<Node>();
        List<Node> work = new List<Node>();

        //reset values to start node
        start.historial = new List<Node>();
        start.g = 0;
        start.h = Vector3.Distance(start.transform.position, end.transform.position);

        visited.Add(start);
        work.Add(start);

        while (work.Count > 0)
        {
            //get current node
            Node current = work[0];
            for (int i = 1; i < work.Count; i++)
            {
                if (work[i].F < current.F) { current = work[i]; }
            }

           // Debug.Log("current: " current.transform.name + " " + current.F );
            work.Remove(current);
            if (current == end) {
                List<Node> resultado = current.historial;
                resultado.Add(current);
                return resultado;
            }
            else{
                for(int i=0; i<current.children.Length; i++)
                {
                    Node currentChild = current.children[i];
                    if (!visited.Contains(currentChild))
                    {
                        
                        currentChild.g = current.g
                            + Vector3.Distance(current.transform.position, currentChild.transform.position);
                        currentChild.h = Vector3.Distance(currentChild.transform.position, end.transform.position);

                        currentChild.historial = new List<Node>(current.historial);
                        currentChild.historial.Add(current);

                        if (currentChild == end)
                        {
                            currentChild.historial.Add(currentChild);
                            return currentChild.historial;
                        }

                        visited.Add(currentChild);
                        work.Add(currentChild);
                    }
                }
            }

        }
        return null;
    }
    
}
