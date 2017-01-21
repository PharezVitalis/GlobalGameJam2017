using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SatelitteMovement : FromToMovement{

    private AudioSource satelitteRocket;

    [SerializeField]
    private float timeAtFadeStart = 0.4f;



	// Use this for initialization
	void Start () {

        satelitteRocket = GetComponent<AudioSource>();
        satelitteRocket.loop = true;
        //satelitteRocket.clip = ADD THIS
        

	}
	
    void Update()
    {
        CheckTime();
    }

    void CheckTime()
    {
        float timeLeft = Distance / Speed;
        if ( timeLeft<= timeAtFadeStart)
        {
            StartCoroutine(FadeSound());
        }

    }
	
    IEnumerator FadeSound()
    {
        while (satelitteRocket.volume > 0.05f)
        {
            satelitteRocket.volume -= Time.fixedDeltaTime * (1 / timeAtFadeStart);

            yield return new WaitForFixedUpdate();
        }
    }
	
    void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

}
