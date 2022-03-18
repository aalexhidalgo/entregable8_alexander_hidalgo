using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    //Lista de canciones
    public AudioClip[] MusicArray;
    public int CurrentSong;
    public string[] NameSong;

    private AudioSource PlayerAudioSource;
    public TextMeshProUGUI TitleSong;

    //EXTRA
    public Sprite[] AlbumArray;
    public Image Portada;
    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a la component AudioSource
        PlayerAudioSource = GetComponent<AudioSource>();
        //Iniciamos con la primera canción en la lista
        PlayerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
        Portada = GameObject.Find("Portada").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizamos el nombre de la canción por la que se está escuchando en ese momento
        TitleSong.text = NameSong[CurrentSong];
        //AlbumArray[Portada];
    }

    public void Next()
    {
        CurrentSong++;
        //Portada++;

        if(CurrentSong >= MusicArray.Length)
        {
            CurrentSong = 0;
            //Portada = 0;
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

