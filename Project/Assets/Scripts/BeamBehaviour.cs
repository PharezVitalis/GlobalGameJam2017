using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
public class BeamBehaviour : MonoBehaviour {

    

    Rigidbody2D rbody;

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float maxDist = 10;
    private float cDist = 0;

    AudioSource beamEffect;
   
    private float startTime; 
    [SerializeField]
    private float checkFreq = 0.2f;
    

	// Use this for initialization
	void Awake ()
    {
        rbody = GetComponent<Rigidbody2D>();

        beamEffect = GetComponent<AudioSource>();

        
	}
	
	// Update is called once per frame
	void OnEnable()
    {
        if (!beamEffect.clip)
        {
            beamEffect.loop = true;
            beamEffect.clip = SoundManager.instance.GetSpot("BeamEffect");
        }

        rbody.velocity = speed * (Vector2)transform.forward;
        cDist = 0;
        startTime = Time.time;

        InvokeRepeating("CheckDist", checkFreq, checkFreq);

        
        beamEffect.Play();
    }

    void CheckDist()
    {
        cDist = rbody.velocity.magnitude * (Time.time - startTime);
        beamEffect.volume = (maxDist - cDist)/maxDist;

        if (cDist> maxDist)
        {
            gameObject.SetActive(false);
        }

    }

    void OnDistable()
    {
        CancelInvoke();
        beamEffect.Stop();
    }
    
    public void ResetRange()
    {
        cDist = 0;
        beamEffect.volume = 1;
        startTime = Time.time;

        CancelInvoke();
        InvokeRepeating("CheckDist", 0, checkFreq);
    }

}
