using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
    [SerializeField]
    private AudioClip[] ambience;
    [SerializeField]
    private string[] ambientNames;

    private AudioSource musicSource, ambienceSource;


    [SerializeField]
    private AudioClip[] spot;
    [SerializeField]
    private string[] spotNames;
    

    [SerializeField]
    private AudioClip[] music;
    [SerializeField]
   private string[] musicNames;
  


    // Use this for initialization
    public static SoundManager instance;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        musicSource = GetComponent<AudioSource>();
       
        
        ambienceSource = GetComponentInChildren<AudioSource>();

    }

    public void PlayMusic(string name)
    {
        for (int i = 0; i < musicNames.Length; i++)
        {
            if (name == musicNames[i])
            {
                musicSource.clip = music[i];
                musicSource.loop = true;
                musicSource.Play();
                return;
            }
        }
    }

    public void PlayAmbience(string name)
    {
        for (int i = 0; i < ambientNames.Length; i++)
        {
            if (name == ambientNames[i])
            {
                ambienceSource.clip = ambience[i];
                ambienceSource.loop = true;
                ambienceSource.Play();
                return;
            }
        }
    }

    public bool AmbienceIsPlaying()
    {
        return ambienceSource.isPlaying;
    }

    public bool MusicIsPlaying()
    {
        return musicSource.isPlaying;
    }

    public AudioClip GetAmbience(string name)
    {
        for (int i = 0; i <ambientNames.Length; i++)
        {
            if (name == ambientNames[i])
            {


                return ambience[i];
            }
        }
        return null;
    }

    public AudioClip GetSpot(string name)
    {
        for (int i = 0; i < spotNames.Length; i++)
        {
            if (name == spotNames[i])
            {


                return spot[i];
            }
        }
        return null;
    }

    public AudioClip GetMusic (string name)
    {
        for (int i = 0; i < musicNames.Length; i++)
        {
            if (name == musicNames[i])
            {


                return music[i];
            }
        }
        return null;
    }
}
