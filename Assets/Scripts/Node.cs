using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
public class Node : MonoBehaviour {

    [XmlAttribute("id")]
    int id;
    [XmlElementAttribute("valid")]
    bool valid;
    [XmlElementAttribute("x-coordinate")]
    float x;
    [XmlElementAttribute("y-coordinate")]
    float y;
    [XmlElementAttribute("url")]
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
//para esto esta calse no deberia heredar de MonoBehaviour

//Asi mismo hay varis valores que se pueden tratar como dicionarios, casi siempre son dupetas, por ahora esto es suficiente