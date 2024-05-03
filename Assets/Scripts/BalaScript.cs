using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    public float velocidad;
    private new Rigidbody2D rigidbody2D;
    private Vector2 Direccion;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // dispara a la derecha o izquierda agregando la velocidad
        rigidbody2D.velocity = Direccion * velocidad;
    }

    public void SetDireccion(Vector2 direccion){
        Direccion = direccion;
        if(Direccion.x<0) transform.localScale = new Vector3(0.3684738f,0.3949802f,1.0f);
        else transform.localScale = new Vector3(-0.3684738f,0.3949802f,1.0f);
    }

    // este método lo llama el evento creado en la animación de la bala
    public void DestroyBala(){
        Destroy(gameObject);
    }
}
