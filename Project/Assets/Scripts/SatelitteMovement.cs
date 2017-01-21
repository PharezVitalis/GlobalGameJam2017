using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SatelitteMovement : FromToMovement{

    //private AudioSource satelitteRocket;

    [SerializeField]
    private float timeAtFadeStart = 0.4f;



	// Use this for initialization
	void Start () {

        //satelitteRocket = GetComponent<AudioSource>();
        //satelitteRocket.loop = true;
        //satelitteRocket.clip = ADD THIS
        //Invoke Checktime Repeating DO NOT USE UPDATE!

	}
	
    

    void CheckTime()
    {
        float timeLeft = Distance / Speed;
        if ( timeLeft<= timeAtFadeStart)
        {
            //StartCoroutine(FadeSound());
        }

    }
	
    //IEnumerator FadeSound()
    //{
    //    while (satelitteRocket.volume > 0.05f)
    //    {
    //        satelitteRocket.volume -= Time.fixedDeltaTime * (1 / timeAtFadeStart);

    //        yield return new WaitForFixedUpdate();
    //    }
    //satelitteRocket.Stop();
    //}
	
    void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

}
