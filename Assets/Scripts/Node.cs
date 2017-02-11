using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

    public int id;
    public bool valid;
    public float x;
    public float y;
    public string url;
    //tiene un array de escalares y un array de labels, por ahora seran omitidos
    //quiz estos no deban ser nodes, sino, solo nobres los ides;
    //quiz esto deberian ser pares de un tipo int, float; nodo distancia, editar despues
    //el padre seria un par de esos, y los hijos estarian en una lista
    public int parent;
    public float parentDistance;
    public int son1;//quiz deba ser un arreglo de hijos
    public int son2;
    public List<int> sons;
    public List<float> sonsDistance;
    public string title;
    public string filename;
    public GameObject esfera;
    void Start () {
    
    }
    
    void Update () {
    
    }
}
//esta clase servira para poder almacenar en una estructura los datos el xml, no seran las clases cuyas instancias estaran en la visualización
//en este camino, debo tener mi clase nodo, esta clas sera uasda en la calse, load xml, cuando lea el xml utilizare la información para crear nodos, y listo.

//Asi mismo hay varis valores que se pueden tratar como dicionarios, casi siempre son dupetas, por ahora esto es suficiente