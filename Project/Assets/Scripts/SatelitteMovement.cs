using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SatelitteMovement : FromToMovement{

    private AudioSource satelitteRocket;

    [SerializeField]
    private float timeAtFadeStart = 0.4f;
    [SerializeField]
    private float fadeTime = 0.2f;


	// Use this for initialization
	void Awake ()
    {
        satelitteRocket = GetComponent<AudioSource>();
        satelitteRocket.loop = true;
    }

    void OnEnable()
    {
       
        satelitteRocket.clip = SoundManager.instance.GetSpot("RocketLaunch");

        

       

        InvokeRepeating("CheckTime", 0.1f, 0.1f);
    }
	
    

    void CheckTime()
    {
        if (!HasTarget)
        {
            return;
        }
        else if (!satelitteRocket.isPlaying)
        {
            satelitteRocket.Play();
        }

        float timeLeft = Distance / Speed;
        if ( timeLeft<= timeAtFadeStart)
        {
            StartCoroutine(FadeSound());
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
    }

    void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

}
