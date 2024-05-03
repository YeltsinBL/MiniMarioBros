using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void SeleccionarAudio(int indice, float volumen){
        audioSource.PlayOneShot(audios[indice], volumen);
    }
    public void DetenerAudio(){
        audioSource.Stop();
    }
}
