using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
public class BeamBehaviour : MonoBehaviour {

    

    Rigidbody2D rbody;

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float timeOut = 10, fadeOutTime = 0.5f;

    bool isBeingSlowed = false;

    float totalDistance = 0;
    Vector2 prevPosition = Vector2.zero;
   
    AudioSource beamEffect;
   
    private float startTime, spawnTime, initialVol;
    [SerializeField]
    private float checkFreq = 0.1f, decalDropRate = 0.2f;

    [SerializeField]
    private Sprite[] decalVars;

    private SpriteRenderer rend;

	void Awake ()
    {
        rbody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
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
        InvokeRepeating("SpawnDecal", decalDropRate, decalDropRate);
       
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

    IEnumerator FadeToDeath()
    {
        while(beamEffect.volume > 0)
        {
            beamEffect.volume -= Time.fixedDeltaTime * (1 / fadeOutTime);
            yield return new WaitForFixedUpdate();
        }

        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
        beamEffect.Stop();
        beamEffect.volume = initialVol;
        StopAllCoroutines();
    }
    
    public void ReachedGoal()
    {
        rbody.velocity = Vector2.zero;

        print("I know where I am");

        LevelManager.instance.PuzzleSolved(totalDistance);
    }

    public void ResetRange()
    {

        beamEffect.volume = initialVol;
        startTime = Time.time;
        rbody.velocity = speed * (Vector2)transform.up;
        
    }

    void SpawnDecal()
    {
        int index = Mathf.RoundToInt(Random.RandomRange(0, decalVars.Length));

        GameObject decal = Pooler.current.GetPooled("Decal");
        decal.transform.position = transform.position;
        decal.GetComponent<Decal>().rend.sprite = decalVars[index];
        decal.SetActive(true);
        
        index = Mathf.RoundToInt(Random.RandomRange(0, decalVars.Length));

        rend.sprite = decalVars[index];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.tag == "Goal")
        {
            ReachedGoal();
            StartCoroutine(FadeToDeath());
        }
        else if (other.tag == "Satellite")
        {
            return;
        }
        else if (other.tag == "Slower")
        {
           speed -= speed* other.GetComponent<Slower>().Rate;

            rbody.velocity = speed * (Vector2)transform.up;
        }
        else if (other.tag == "Obstacle" ||other.tag=="Planet" )
        {
            StartCoroutine(FadeToDeath());
        }
       


    }

    



}
