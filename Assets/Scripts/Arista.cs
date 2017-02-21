using UnityEngine;
using System.Collections;

public class Arista : MonoBehaviour {
    public int source;
    public int target;
    public Transform sourceT;//estos trransform se deben llenar cuando se instancien estas aristas, y si se puede a traves del script Edge
    public Transform targetT;
    public LineRenderer linea;
    public Vector3 lastPositionSource;
    public Vector3 lastPositionTarget;
    void Start(){
        linea = GetComponent<LineRenderer>();
        lastPositionSource = Vector3.zero;
        lastPositionTarget = Vector3.zero;

    }
    void FixedUpdate(){
        ActualizarPuntos();//no se si siempre deba estar reemplazando, o solo deba hacer este cambio si hubiese cambiado algunos de los nodos
    }
    public void ActualizarPuntos(){//deberia verficar si los nodos cambiaron de posicion, si es asi recien actualizar, no se que tanto mejore solo esa comprobacion
        if(lastPositionSource != sourceT.position){//esto se puede hacer de otra forma, o no hacerlo, no parece haber un impacto en el rendimiento
            linea.SetPosition(0, sourceT.position);
            lastPositionSource = sourceT.position;
        }
        if(lastPositionTarget != targetT.position){
            linea.SetPosition(1, targetT.position);
            lastPositionTarget = targetT.position;
        }
    }

}