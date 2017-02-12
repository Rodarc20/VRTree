using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node {

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
    public void CopyTo(){//copiar datos al script de la esfera
        Nodo esferaNodo = esfera.GetComponent<Nodo>();
        esferaNodo.id = id;
        esferaNodo.valid = valid;
        esferaNodo.sons = sons;//tener cuidado con esto, ya que creo que hacen referencia a la misma lista quiza no sea necesario copiarla, mas que al inicio, cuando se instancie, por ahora dejar asi
        esferaNodo.filename = filename;
        esferaNodo.title = title;
        esferaNodo.parent = parent;
        esferaNodo.url = url;
    }
    public void CopyFrom(){//copiar datos desde el script de la esfera
        Nodo esferaNodo = esfera.GetComponent<Nodo>();
        id = esferaNodo.id;
        valid = esferaNodo.valid;
        sons = esferaNodo.sons;//tener cuidado con esto, ya que creo que hacen referencia a la misma lista quiza no sea necesario copiarla, mas que al inicio, cuando se instancie, por ahora dejar asi
        filename = esferaNodo.filename;
        title = esferaNodo.title;
        parent = esferaNodo.parent;
        url = esferaNodo.url;
    }
}
//esta clase servira para poder almacenar en una estructura los datos el xml, no seran las clases cuyas instancias estaran en la visualización
//en este camino, debo tener mi clase nodo, esta clas sera uasda en la calse, load xml, cuando lea el xml utilizare la información para crear nodos, y listo.

//Asi mismo hay varis valores que se pueden tratar como dicionarios, casi siempre son dupetas, por ahora esto es suficiente