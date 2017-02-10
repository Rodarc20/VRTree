using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class AplicationControler : MonoBehaviour {
    [HideInInspector] public List<Node> nodos;
    [HideInInspector] public List<Edge> aristas;
    public GameObject node;
    public XmlLoader xmlLoader;
    GameObject board;//espacio sobre el que estaran los nodos, que en cierto modo, este script estara en ese objeto

    void Start(){
        xmlLoader = GetComponent<XmlLoader>();
        if(xmlLoader){
            nodos = xmlLoader.nodos;
            aristas = xmlLoader.aristas;
            print("cargado");
        }
        else{
            print("no");
        }
        print(nodos.Count);//esto deberi cargarse despues de que cmloadr cumpla su funcion
        //Vertexs();
    }
    void Vertexs(){
       foreach(Node nodo in nodos){
            GameObject obj = Instantiate(node, new Vector3(nodo.x, nodo.y, 0f), transform.rotation) as GameObject;
            nodo.esfera = obj;
        }
    }
    
    void Update(){

    }

}
//este script debe estar ligado al de carga del xml para poder recibir la lista d nodos y aristas
//node no pertenece a unas instancion de un gameObject
//reemplazar las listas por arboles

//esta visualización, creaara nodos para para cada scprior node.cs, esos scripts no seran herencia de monobehaviour
//es decir node.cs tendra instancis del gameobject Node, de esta foma cada uno de esos scripts instanciara su respectivo nodo