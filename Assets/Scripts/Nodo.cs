using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Nodo : MonoBehaviour {

    public int id;
    public int orden;
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
    public Text texto;
    void Start () {
    }
    
    void Update () {
    
    }
    public void mostrarTexto(){//como este script tiene , los datos dentro, el texto lo debo generar de aqui;el unico dato que se llena al momento es el del orde, que podria recibirloen esta funion o no
        texto = GetComponentInChildren<Text>();
        if(texto){
            string s =  id + " (" + orden + ")";
            texto.text = s;
        }
    }
}
//este script va en cada objeto nodo, tambien se usara como si fuera los elementos de la estructura de datos
//reducir a los datos strictamente necesarios, por ahora solo el id