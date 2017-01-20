﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
    [SerializeField]
    AudioClip[] ambience;
    [SerializeField]
    string[] ambientNames;

    [SerializeField]
    AudioClip[] spot;
    [SerializeField]
    string[] spotNames;

    [SerializeField]
    AudioClip[] music;
    [SerializeField]
    string[] musicNames;

   

    // Use this for initialization
    public static SoundManager instance;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
