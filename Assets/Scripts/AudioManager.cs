using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Lista de canciones
    public AudioClip[] MusicArray;
    public int CurrentSong;

    private AudioSource PlayerAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a la component AudioSource
        PlayerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
