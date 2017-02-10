using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class AplicationControler : MonoBehaviour {
    List<Node> nodos;
    void start(){

    }
    void update(){

    }

}
//este script debe estar ligado al de carga del xml para poder recibir la lista d nodos y aristas
//node no pertenece a unas instancion de un gameObject
//en esta visualizacion, node.cs sera un script para cada gameobject Node, por lo tanto esta aplicacion, al momento de recuperar datos debera instanciar un objeto y alli llenar datos en los objetos instnaciados