using UnityEngine;

public class Edge {
    public int source;
    public int target;
    public float length;
    public GameObject linea;   
    public void CopyTo(){
        Arista lineaArista = linea.GetComponent<Arista>();
        lineaArista.source = source;
        lineaArista.target = target;
    }
}

//agregar getters y setters
//debo traladar las funcioenes update a otro script que ira como componetn del objeto linea, este sera enccargado de rastrea la posicion del nodo que se necestia