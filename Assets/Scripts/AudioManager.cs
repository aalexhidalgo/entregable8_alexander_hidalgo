using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    //Lista de canciones
    public AudioClip[] MusicArray;
    public int CurrentSong;
    public string[] NameSong;

    private AudioSource PlayerAudioSource;
    public TextMeshProUGUI TitleSong;

    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a la component AudioSource
        PlayerAudioSource = GetComponent<AudioSource>();
        //Iniciamos con la primera canci�n en la lista
        PlayerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizamos el nombre de la canci�n por la que se est� escuchando en ese momento
        TitleSong.text = NameSong[CurrentSong];
    }

    public void Next()
    {
        CurrentSong++;

        if(CurrentSong >= MusicArray.Length)
        {
            CurrentSong = 0;
        }

        PlayerAudioSource.Stop();
        PlayerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    public void Back()
    {
        CurrentSong--;

        if (CurrentSong < 0)
        {
            CurrentSong = MusicArray.Length - 1;
        }

        PlayerAudioSource.Stop();
        PlayerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    public void Pause()
    {
        PlayerAudioSource.Pause();
    }

    public void Play()
    {
        PlayerAudioSource.UnPause();
    }

    public void ChooseRandomly()
    {
        PlayerAudioSource.Stop();
        CurrentSong = Random.Range(0, MusicArray.Length);
        PlayerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }
}

