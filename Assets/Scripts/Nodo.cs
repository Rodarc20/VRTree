using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Nodo : MonoBehaviour {

    public int id;
    public bool valid;
    //public float x;//este
    //public float y;
    //tanto x como y estan en el transform, asi que no es necesario tener esas variables
    public string url;
    public int parent;
    public float parentDistance;
    public int son1;
    public int son2;
    public List<int> sons;
    public List<float> sonsDistance;//no se usa solo es para saber
    public string title;
    public string filename;
    void Start () {
    
    }
    
    void Update () {
    
    }
}
//este script va en cada objeto nodo, tambien se usara como si fuera los elementos de la estructura de datos