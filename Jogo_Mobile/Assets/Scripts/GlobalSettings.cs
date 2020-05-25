using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{

    public static GlobalSettings singleton;
    public float volume;

    private AudioSource[] audios;

    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audios = FindObjectsOfType<AudioSource>();
    }

    private void OnLevelWasLoaded(int level)
    {
        if(singleton == this)
        {
            audios = FindObjectsOfType<AudioSource>();
            UpdateVolume();
        }
    }

    public void UpdateVolume()
    {
        foreach(AudioSource audio in audios)
        {
            audio.volume = volume;
        }
    }
}
