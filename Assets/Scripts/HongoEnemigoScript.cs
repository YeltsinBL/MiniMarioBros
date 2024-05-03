using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongoEnemigoScript : MonoBehaviour
{
    public GameObject Mario;
    
    private Animator animator;
    private new Rigidbody2D rigidbody2D;

    public float speed; // velocidad
    private bool direccion=false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Mario == null) return;
        
        // obtenemos el valor obsoluto de la distancia de los personajes para que se mueva el hongo
        float distancia = Mathf.Abs(Mario.transform.position.x - transform.position.x);
         
        if(distancia < 4.6f){ // valor absoluto
            animator.SetBool("Running", true);
        }
        else {
            animator.SetBool("Running", false);
        }
    }
    
    // Mover al personaje
    private void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(direccion?1:-1 * speed, rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        TunelScript tunel = other.collider.GetComponent<TunelScript>();
        if(tunel != null) direccion= !direccion;
        
    }

    public void AnimaAplatado(bool estado){
        animator.SetBool("Crushing", estado);
        if (estado) Destroy(gameObject);
    }
    
}
