using UnityEngine;

public class BoardController : MonoBehaviour {
    private Vector3 movimiento;
    public float velocidad = 100f;
    void Start(){

    }
    void FixedUpdate(){
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movimiento.Set(x, y, 0f);
        transform.Translate(movimiento.normalized * velocidad * Time.deltaTime);
    }
}