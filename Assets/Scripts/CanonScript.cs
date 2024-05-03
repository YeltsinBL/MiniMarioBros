using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public GameObject BalaPrefab;
    public GameObject Mario;

    private float ultimaBala;

    // Update is called once per frame
    void Update()
    {
        if(Mario == null) return;
        // distancia de mario para disparar y depende también del tiempo
        float distancia = Mathf.Abs(Mario.transform.position.x - transform.position.x);
        if(distancia < 4.6f && Time.time > ultimaBala +1.0f) {
            Disparar();
            ultimaBala = Time.time;
        }
    }
    
    private void Disparar(){
        Vector3 direccion;
        if(Mario.transform.position.x > transform.position.x) direccion = Vector2.right;
        else direccion = Vector2.left;
        // obtiene el prefab(la bala), dispara desde su posición (el cañon) y sin rotación
        GameObject bala = Instantiate(BalaPrefab, transform.position + direccion * 0.1f, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDireccion(direccion);
    }
}
