using UnityEngine;
using System.Collections;

public class Arista : MonoBehaviour {
    public int source;
    public int target;
    public Transform sourceT;//estos trransform se deben llenar cuando se instancien estas aristas, y si se puede a traves del script Edge
    public Transform targetT;
    public LineRenderer linea;
    void Start(){
        linea = GetComponent<LineRenderer>();

    }
    void Update(){
        ActualizarPuntos();//no se si siempre deba estar reemplazando, o solo deba hacer este cambio si hubiese cambiado algunos de los nodos
    }
    public void ActualizarPuntos(){
        linea.SetPosition(0, sourceT.position);
        linea.SetPosition(1, targetT.position);
    }

}