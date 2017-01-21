using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SatelitteMovement : FromToMovement
{

    private AudioSource sateliteRocket;
    private AudioClip rocketLaunch;
    private AudioClip arrivalBeep;
    private float initialVolume;

    bool couroutineStarted = false;

    [SerializeField]
    private float timeAtFadeStart = 0.4f;
    [SerializeField]
    private float fadeTime = 0.2f;


    // Use this for initialization
    void Awake()
    {
        sateliteRocket = GetComponent<AudioSource>();
        sateliteRocket.loop = true;
        initialVolume = sateliteRocket.volume;
    }

    void OnEnable()
    {

        sateliteRocket.clip = rocketLaunch = SoundManager.instance.GetSpot("RocketLaunch");
        arrivalBeep = SoundManager.instance.GetSpot("TechBeepsLong");
        sateliteRocket.loop = true;
        sateliteRocket.volume = initialVolume;

        sateliteRocket.Play();
        

        InvokeRepeating("CheckTime", 0.1f, 0.1f);
    }



    void CheckTime()
    {
        if (!HasTarget)
        {
            CancelInvoke();
            return;            
        }


        float timeLeft = Distance / Speed;
        if (timeLeft <= timeAtFadeStart)
        {
            if (!couroutineStarted)
            {
                StartCoroutine(FadeSound());
                couroutineStarted = true;
            }

        }

    }

    IEnumerator FadeSound()
    {
        while (sateliteRocket.volume > 0.01f)
        {
            sateliteRocket.volume -= Time.fixedDeltaTime * (1 / fadeTime);

            yield return new WaitForFixedUpdate();
        }

        sateliteRocket.Stop();
        sateliteRocket.loop = false;
        sateliteRocket.clip = arrivalBeep;

        sateliteRocket.volume = initialVolume;
        yield return new WaitForFixedUpdate();
        sateliteRocket.Play();
        CancelInvoke();
    }

    void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

}
