using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

    int id;
    bool valid;
    float x;
    float y;
    string url;
    //tiene un array de escalares y un array de labels, por ahora seran omitidos
    //quiz estos no deban ser nodes, sino, solo nobres los ides;
    int parent;
    int son1;//quiz deba ser un arreglo de hijos
    int son2;
    List<int> sons;
    string title;
    string filename;
    void Start () {
    
    }
    
    void Update () {
    
    }
}
//esta clase servira para poder almacenar en una estructura los datos el xml, no seran las clases cuyas instancias estaran en la visualización

//Asi mismo hay varis valores que se pueden tratar como dicionarios, casi siempre son dupetas, por ahora esto es suficiente