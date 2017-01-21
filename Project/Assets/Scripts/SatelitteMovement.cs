using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SatelitteMovement : FromToMovement{

    private AudioSource satelitteRocket;
    private AudioClip rocketLaunch;
    private AudioClip arrivalBeep;
    private float initialVolume;

    bool couroutineStarted = false;

    [SerializeField]
    private float timeAtFadeStart = 0.4f;
    [SerializeField]
    private float fadeTime = 0.2f;


	// Use this for initialization
	void Awake ()
    {
        satelitteRocket = GetComponent<AudioSource>();
        satelitteRocket.loop = true;
        initialVolume = satelitteRocket.volume;
    }

    void OnEnable()
    {
       
        satelitteRocket.clip = rocketLaunch = SoundManager.instance.GetSpot("RocketLaunch");
        arrivalBeep = SoundManager.instance.GetSpot("TechBeepsShort");
        satelitteRocket.loop = true;
        satelitteRocket.volume = initialVolume;

        satelitteRocket.Play();
        print(arrivalBeep);

        InvokeRepeating("CheckTime", 0.1f, 0.1f);
    }
	
    

    void CheckTime()
    {
        if (!HasTarget)
        {
            return;
        }
        

        float timeLeft = Distance / Speed;
        if ( timeLeft<= timeAtFadeStart)
        {
            if (! couroutineStarted)
            {
                StartCoroutine(FadeSound());
                couroutineStarted = true;
            }
            
        }

    }

    IEnumerator FadeSound()
    {
        while (satelitteRocket.volume > 0.01f)
        {
            satelitteRocket.volume -= Time.fixedDeltaTime * (1 / fadeTime);

            yield return new WaitForFixedUpdate();
        }
      
        satelitteRocket.Stop();
        satelitteRocket.loop = false;
        satelitteRocket.clip = arrivalBeep;

        satelitteRocket.volume = initialVolume;
        yield return new WaitForFixedUpdate();
        satelitteRocket.Play();
        CancelInvoke();
    }

    void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

}
