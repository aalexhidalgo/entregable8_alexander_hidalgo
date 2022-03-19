using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    //Lista de canciones (nombres y clips)
    public AudioClip[] MusicArray;
    public string[] NameSong;

    public int CurrentSong;

    private AudioSource AudioManagerAudioSource;

    //Bloque de texto donde se mostrará el nombre de la canción
    public TextMeshProUGUI TitleSong;

    //EXTRA: Cada canción va acompañada por una portada de disco diferente que se actualizará dependiendo de los botones de Next, Back y ChooseRandomly
    public Sprite[] AlbumArray;
    public Image Portada;

    //EXTRA: Controlamos el volumen a través de un Slider
    public Slider SliderVolume;
    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a la component AudioSource
        AudioManagerAudioSource = GetComponent<AudioSource>();
        //Iniciamos con la primera canción en la lista
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
        //Accedemos a la portada y a su componente Image
        Portada = GameObject.Find("Portada").GetComponent<Image>();
        Portada.sprite = AlbumArray[CurrentSong];
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizamos el nombre de la canción por la que se está escuchando en ese momento
        TitleSong.text = NameSong[CurrentSong];
        //Actualizamos la portada del disco de la canción po la que se está escuchando en ese momento
        Portada.sprite = AlbumArray[CurrentSong];
    }

    //Botón a la siguiente canción y su portada
    public void Next()
    {
        CurrentSong++;

        //Cuando superemos el número de canciones por lista, si volvemos a pulsarbotón, este contador se reiniciará volviendo a la primera canción de la lista (0)
        if (CurrentSong >= MusicArray.Length)
        {
            CurrentSong = 0;
        }

        //Le indicamos que si pasa a la siguiente canción detenga la anterior para que no se solapen los clips
        AudioManagerAudioSource.Stop();
        //Ejecuta la canción actual
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    //Botón a la canción anterior y su portada
    public void Back()
    {
        CurrentSong--;

        //Cuando superemos en negativo el mínimo de canciones por lista (0), si volvemos a pulsarbotón, este contador nos llevará a la última canción (4)
        if (CurrentSong < 0)
        {
            CurrentSong = MusicArray.Length - 1;
        }

        //Le indicamos que si pasa a la siguiente canción detenga la anterior para que no se solapen los clips
        AudioManagerAudioSource.Stop();
        //Ejecuta la canción actual
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    //Botón que pausa la canción actual
    public void Pause()
    {
        AudioManagerAudioSource.Pause();
    }

    //Botón que reanuda la canción actual
    public void Play()
    {
        AudioManagerAudioSource.UnPause();
    }

    //Botón que elige de manera random la canción actual (conservando su portada)
    public void ChooseRandomly()
    {
        AudioManagerAudioSource.Stop();
        CurrentSong = Random.Range(0, MusicArray.Length);
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    //EXTRA: Botón que reinicia la canción actual
    public void Restart()
    {
        AudioManagerAudioSource.Stop();
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    //EXTRA: Conectamos el volumen del Audiousource con el valor del Slider
    public void UpdateVolume()
    {
        AudioManagerAudioSource.volume = SliderVolume.value;
    }
}

