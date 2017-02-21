using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;

public class AplicationControler : MonoBehaviour {
    [HideInInspector] public List<Node> nodos;
    [HideInInspector] public List<Edge> aristas;
    public GameObject node;
    public GameObject nodeI;
    public GameObject edge;
    public Material nodeValid;
    public Material nodeInvalid;
    [HideInInspector] public XmlLoader xmlLoader;
    GameObject board;//espacio sobre el que estaran los nodos, que en cierto modo, este script estara en ese objeto
    int boardMask;
    int moveMask;
    Ray pointerRay;
    RaycastHit pointerRayHit;
    float rayRange = 2000f;//este se deberia calcular solo en base a la cantidad de nodos
    public float maxY = 0;
    public float maxX = 0;
    Transform nodeSelected;//node seleccionado
    bool selectedNode;//para controlar si hay algun nodo seleccionado
    List<Transform> nodosAfectados;

    void Start(){
        selectedNode = false;
        boardMask = LayerMask.GetMask("Board");
        moveMask = LayerMask.GetMask("Move");
        xmlLoader = GetComponent<XmlLoader>();
        if(xmlLoader){
            nodos = xmlLoader.nodos;
            //aristas = xmlLoader.aristas;
            print("cargado");
        }
        else{
            print("no");
        }
        //print(nodos.Count);//esto deberi cargarse despues de que cmloadr cumpla su funcion
        Vertexs();
        transform.position = new Vector3 (-1*maxX/2, maxY/2, 0f);
        nodosAfectados = new List<Transform>();
        Edges();
    }
    void Vertexs(){
       foreach(Node nodo in nodos){
            if(nodo.valid){
                GameObject obj = Instantiate(node, new Vector3(nodo.x, -1*nodo.y, 0f), transform.rotation) as GameObject;
                nodo.esfera = obj;
                nodo.esfera.transform.SetParent(transform);//se puede quitar
                //nodo.esfera.GetComponent<Renderer>().material = nodeValid;
            }
            else{
                GameObject obj = Instantiate(nodeI, new Vector3(nodo.x, -1*nodo.y, 0f), transform.rotation) as GameObject;
                nodo.esfera = obj;
                nodo.esfera.transform.SetParent(transform);//se puede quitar
                //nodo.esfera.GetComponent<Renderer>().material = nodeInvalid;
            }
            nodo.CopyTo();
            if(nodo.x > maxX)
                maxX = nodo.x;
            if(nodo.y > maxY)
                maxY = nodo.y;
            //aristas//debe ser en otra funcion por que aun no estan todos los vertices instancias, para obtener sus transform
            nodo.esfera.GetComponent<Nodo>().mostrarTexto();//esto debe estar en otro lado
        }
    }
    
    void Edges(){//usar el orden de los nodos, ya no los sdges del xml
        for(int i = 0; i < nodos.Count-1; i++){
                GameObject obj = Instantiate(edge, transform.position, transform.rotation) as GameObject;
                obj.GetComponent<Arista>().sourceT = nodos[nodos[i].id].esfera.transform;
                obj.GetComponent<Arista>().targetT = nodos[nodos[i].parent].esfera.transform;
                obj.transform.SetParent(transform);//se puede quitar
                nodos[i].esfera.GetComponent<Nodo>().mostrarTexto();//esto debe estar en otro lado
        }
    }

    void FixedUpdate(){//no hay mucha diferencia si solo uso Update()
        //esto es el arrastre, este arrastre se debe aplicar a cada nodo
        if(Input.GetButtonDown("Fire1") && !selectedNode){//aqui debo detectar si ha dado click sobre algun nodo
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(camRay, out hit, rayRange, moveMask)){
                nodeSelected = hit.collider.GetComponent<Transform>();
                seleccionarNodosAfectados(nodeSelected.GetComponent<Nodo>().id);//para la segunda forma
                selectedNode = true;
                print("Nodo seleccionado");
            }
        }
        else if(Input.GetButton("Fire1") && selectedNode){//aqui debo verificar que haya seleccionado algun nodo, y cambiar la posicion de ese nodo, a la posicion dl cursor
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(camRay, out hit, rayRange, boardMask)){
                Vector3 traslacion = hit.point - nodeSelected.position;
                //nodeSelected.position = hit.point;
                //nodeSelected.Translate(traslacion);
                //print(nodeSelected.GetComponent<Nodo>().id);
                //trasladarRama(nodeSelected.GetComponent<Nodo>().id, traslacion);//forma 1
                aplicarTraslacion(traslacion);//forma2
            }
        }
        else if(Input.GetButtonUp("Fire1") && selectedNode){//aqui debo dejar de actualizr los nodos
            selectedNode = false;
            nodeSelected = null;
            nodosAfectados.Clear();//modificacion a 2 
        }
    }

    public void trasladarRama(int idNodo, Vector3 traslacion){//usar un bfs// paa esta funcion quiza solo necestio el indice, este indice se obtiene del script Nodo de la esfera, de alli debo sacar el id
        //usar el arreglo de Nodes, y solo acceder a las esferas y a su transform
        Queue<int> cola = new Queue<int>();
        cola.Enqueue(idNodo);
        while(cola.Count != 0){
            idNodo = cola.Dequeue();
            nodos[idNodo].esfera.transform.Translate(traslacion);
            foreach (int item in nodos[idNodo].sons) {
                cola.Enqueue(item);
            }
        }
    }
    public void seleccionarNodosAfectados(int idNodo){
        //nodosAfectados = new List<Transform> ();
        Queue<int> cola = new Queue<int>();
        cola.Enqueue(idNodo);
        while(cola.Count != 0){
            idNodo = cola.Dequeue();
            nodosAfectados.Add(nodos[idNodo].esfera.transform);
            foreach (int item in nodos[idNodo].sons) {
                cola.Enqueue(item);
            }
        }
    }
    public void aplicarTraslacion(Vector3 traslacion){
        /*foreach(Transform t in nodosAfectados){
            t.Translate(traslacion);
        }*/
        for(int i = 0; i < nodosAfectados.Count; i++){
            nodosAfectados[i].Translate(traslacion);
        }
    }
    /*public void aplicarTraslacion2(Vector3 traslacion){

    }
    public void aplicar(List<Transform> arregloNodos, int i, int j, Vector3 traslacion){}
    */
}

//este script debe estar ligado al de carga del xml para poder recibir la lista d nodos y aristas
//node no pertenece a unas instancion de un gameObject
//reemplazar las listas por arboles

//esta visualización, creaara nodos para para cada scprior node.cs, esos scripts no seran herencia de monobehaviour
//es decir node.cs tendra instancis del gameobject Node, de esta foma cada uno de esos scripts instanciara su respectivo nodo

//para la interaccion, tomar como ejemplo lo de survival shooter
//para esto debo crear un area en la que el raycas que proviene del mouse golpee, esta area entrara en usoa cuadno este arrastrando un nodo.
//pero para detectar que estoy ssuperponiendo el mouse en un nodo, entonces, usare el mismo raycast, pero esta vez collisionara con los nodos, algo como los disparos a los enemigos.
//entre estos dos modos, lo unico que varia es si tengo presionado el boton y si obviamente si colisiono con un nodo.
//el traslado de lo nodos debe arrastra tod la rama, es decir a sus descendientes. para ello debo conservar el vector, de desplazamiento
//y aplicarlo a cada nodo de la rama, para ello seria apropiado sonservar la estructur o recorrer todos lo nodos hijos, en este caso me conviene que el gameObject
//tenga un script con esa información
//luego desde este scrpt hacer una modificaióñ recursiva o iterativa.
//en la estrcutura o usando la lista, ya que esta ordenada como deberia estar, el problema son las aristas