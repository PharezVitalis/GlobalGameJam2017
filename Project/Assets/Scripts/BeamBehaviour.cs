using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
public class BeamBehaviour : MonoBehaviour {

    

    Rigidbody2D rbody;

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float timeOut = 10;

    float totalDistance = 0;
    Vector2 prevPosition = Vector2.zero;
   
    AudioSource beamEffect;
   
    private float startTime, spawnTime, initialVol; 
    [SerializeField]
    private float checkFreq = 0.1f;
    

	
	void Awake ()
    {
        rbody = GetComponent<Rigidbody2D>();

        beamEffect = GetComponent<AudioSource>();
        
        
	}
	
    void Update()
    {
        totalDistance += Vector2.Distance(prevPosition, transform.position);
        prevPosition = transform.position;

    }
	
	void OnEnable()
    {
        if (!beamEffect.clip)
        {
            beamEffect.loop = true;
            beamEffect.clip = SoundManager.instance.GetSpot("BeamEffect");
            initialVol = beamEffect.volume;
        }

        rbody.velocity = speed * (Vector2)transform.up;
        prevPosition = transform.position;

        

        startTime = spawnTime = Time.time;

        InvokeRepeating("AffectVolume", checkFreq, checkFreq);

       
        beamEffect.Play();
    }

   

    void AffectVolume()
    {
        float cTime = Time.time - startTime;

        if (cTime > timeOut)
        {
            gameObject.SetActive(false);
        }
        else
        {
            beamEffect.volume = cTime / timeOut;
        }

        

    }

    

    void OnDisable()
    {
        CancelInvoke();
        beamEffect.Stop();
        beamEffect.volume = initialVol;
       
    }
    
    public void ReachedGoal()
    {
        rbody.velocity = Vector2.zero;
        
        LevelManager.instance.PuzzleSolved(totalDistance);
    }

    public void ResetRange()
    {

        beamEffect.volume = initialVol;
        startTime = Time.time;
        rbody.velocity = speed * (Vector2)transform.up;
    }

    

}
