using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject Mario;
    
    void Update()
    {
        if (Mario == null) {
            Camera.main.GetComponent<AudioSource>().Stop();
            return;
        };
        
        Vector3 position = transform.position;
        position.x = Mario.transform.position.x;
        transform.position = position;
    }

}
