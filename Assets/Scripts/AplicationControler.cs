using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class AplicationControler : MonoBehaviour {
    List<Node> nodos;
    List<Edge> aristas;
    GameObject board;//espacio sobre el que estaran los nodos, que en cierto modo, este script estara en ese objeto

    void start(){
         

    }
    void update(){

    }

}
//este script debe estar ligado al de carga del xml para poder recibir la lista d nodos y aristas
//node no pertenece a unas instancion de un gameObject
//reemplazar las listas por arboles

//esta visualización, creaara nodos para para cada scprior node.cs, esos scripts no seran herencia de monobehaviour