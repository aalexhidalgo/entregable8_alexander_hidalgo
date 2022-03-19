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

    //Bloque de texto donde se mostrar� el nombre de la canci�n
    public TextMeshProUGUI TitleSong;

    //EXTRA: Cada canci�n va acompa�ada por una portada de disco diferente que se actualizar� dependiendo de los botones de Next, Back y ChooseRandomly
    public Sprite[] AlbumArray;
    public Image Portada;

    //EXTRA: Controlamos el volumen a trav�s de un Slider
    public Slider SliderVolume;
    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a la component AudioSource
        AudioManagerAudioSource = GetComponent<AudioSource>();
        //Iniciamos con la primera canci�n en la lista
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
        //Accedemos a la portada y a su componente Image
        Portada = GameObject.Find("Portada").GetComponent<Image>();
        Portada.sprite = AlbumArray[CurrentSong];
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizamos el nombre de la canci�n por la que se est� escuchando en ese momento
        TitleSong.text = NameSong[CurrentSong];
        //Actualizamos la portada del disco de la canci�n po la que se est� escuchando en ese momento
        Portada.sprite = AlbumArray[CurrentSong];
    }

    //Bot�n a la siguiente canci�n y su portada
    public void Next()
    {
        CurrentSong++;

        //Cuando superemos el n�mero de canciones por lista, si volvemos a pulsarbot�n, este contador se reiniciar� volviendo a la primera canci�n de la lista (0)
        if (CurrentSong >= MusicArray.Length)
        {
            CurrentSong = 0;
        }

        //Le indicamos que si pasa a la siguiente canci�n detenga la anterior para que no se solapen los clips
        AudioManagerAudioSource.Stop();
        //Ejecuta la canci�n actual
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    //Bot�n a la canci�n anterior y su portada
    public void Back()
    {
        CurrentSong--;

        //Cuando superemos en negativo el m�nimo de canciones por lista (0), si volvemos a pulsarbot�n, este contador nos llevar� a la �ltima canci�n (4)
        if (CurrentSong < 0)
        {
            CurrentSong = MusicArray.Length - 1;
        }

        //Le indicamos que si pasa a la siguiente canci�n detenga la anterior para que no se solapen los clips
        AudioManagerAudioSource.Stop();
        //Ejecuta la canci�n actual
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    //Bot�n que pausa la canci�n actual
    public void Pause()
    {
        AudioManagerAudioSource.Pause();
    }

    //Bot�n que reanuda la canci�n actual
    public void Play()
    {
        AudioManagerAudioSource.UnPause();
    }

    //Bot�n que elige de manera random la canci�n actual (conservando su portada)
    public void ChooseRandomly()
    {
        AudioManagerAudioSource.Stop();
        CurrentSong = Random.Range(0, MusicArray.Length);
        AudioManagerAudioSource.PlayOneShot(MusicArray[CurrentSong]);
    }

    //EXTRA: Bot�n que reinicia la canci�n actual
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

