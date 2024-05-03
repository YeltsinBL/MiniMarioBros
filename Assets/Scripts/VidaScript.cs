using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VidaScript : MonoBehaviour
{
    public GameObject Mario;
    // Start is called before the first frame update
    public GameObject[] vida;

    // Update is called once per frame
    void Update()
    {
        if(gameObject == null) return;
        if (Mario == null) return;

        Vector3 position = transform.position;
        position.x = Mario.transform.position.x +1.5f;
        transform.position = position;
    }

    public void DesactivarVidas(int indice){
        vida[indice].SetActive(false);
    }
}
