using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private AudioManager audioManager;
    public VidaScript vidaScript;
    private float horizontal;// caminar
    public float speed; // velocidad
    public float jumpForce; // fuerza para saltar
    private bool grounded; // verifica si estamos en el suelo
    private int health = 3; // vida
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // cambiar la mira de Mario (izquierda-derecha)
        if(horizontal < 0.0f) transform.localScale = new Vector3(-1,1,1.0f);
        else if(horizontal > 0.0f) transform.localScale = new Vector3(1,1,1.0f);

        // Activar la animación corriendo
        animator.SetBool("Running", horizontal !=0.0f);

        // Verificar si esta Mario en el suelo
        Debug.DrawRay(transform.position, Vector3.down * 0.09f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.09f)) grounded=true;
        else grounded=false;

        // agregar la tecla espacio para saltar
        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            // seleccionar el audio de saltar
            audioManager.SeleccionarAudio(0, 0.2f);
            Jump();
        } 
        if(!grounded) animator.SetBool("Jumpping",true);
        else animator.SetBool("Jumpping",false);

        if(transform.position.y < -3.3)
            AccionesMorir(transform.position.x - 1.0f, -3.1f);
    }
    // Mover al personaje
    private void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
    }

    // Saltar
    private void Jump(){
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Chocar con el hongo
        HongoEnemigoScript hongoEnemigo = other.collider.GetComponent<HongoEnemigoScript>();
        if(hongoEnemigo != null) {
            // Verificar si estuvo encima del hongo
            float distancia = transform.position.x - hongoEnemigo.transform.position.x;
            float operacion = Mathf.Round(distancia * 100f) / 100f; // Redondeo
            if(operacion < 0.13f && operacion > -0.12f){
                hongoEnemigo.AnimaAplatado(true);
            }else{
                hongoEnemigo.AnimaAplatado(false);
                AccionesMorir(transform.position.x - 1.0f, transform.position.y);
            }
        }
        BalaScript balaScript = other.collider.GetComponent<BalaScript>();
        if(balaScript != null) 
            AccionesMorir(transform.position.x - 1.0f, transform.position.y);
    }

    private void RegresarPosicion(float x, float y){
        Vector3 position = transform.position;
        position.x = x;
        position.y = y;
        transform.position = position;
    }

    private void AccionesMorir(float x, float y) {        
        // seleccionar el audio de choque
        //audioManager.SeleccionarAudio(1, 0.2f);
        RegresarPosicion(x, y);
        Death();
    }

    private void Death() {
        health -=1;
        // seleccionar el audio de choque
        audioManager.SeleccionarAudio(1, 0.2f);
        
        vidaScript.DesactivarVidas(health);
        if(health == 0) {
            audioManager.SeleccionarAudio(2, 0.2f);
            Destroy(gameObject);
        }
    }
}
