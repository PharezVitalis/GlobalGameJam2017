﻿using UnityEngine;
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
   
    private float startTime, spawnTime, endTime; 
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

        rbody.velocity = speed * (Vector2)transform.up;
        cDist = 0;

        

        startTime = spawnTime = Time.time;

        InvokeRepeating("CheckDist", checkFreq, checkFreq);

       
        beamEffect.Play();
    }

    void CheckDist()
    {
        cDist = rbody.velocity.magnitude * (Time.time - startTime);
        beamEffect.volume = (maxDist - cDist)/maxDist;

        print(cDist);
        if (cDist> maxDist)
        {
            gameObject.SetActive(false);
        }

    }

    public void VelocityReset()
    {
        rbody.velocity = speed * (Vector2)transform.up;
    }

    void OnDisable()
    {
        CancelInvoke();
        beamEffect.Stop();
        cDist = 0;

    }
    
    public void ReachedGoal()
    {
        rbody.velocity = Vector2.zero;
        endTime = Time.time;

        LevelManager.instance.PuzzleSolved(TotalDistance);
    }

    public void ResetRange()
    {
        cDist = 0;
        beamEffect.volume = 1;
        startTime = Time.time;

        CancelInvoke();
        InvokeRepeating("CheckDist", 0, checkFreq);
    }

    public float TotalDistance
    {
        get
        {
            if (endTime != 0)
            {
                return (endTime - spawnTime) * speed;
            }
            else
            {
                return (Time.time - spawnTime) * speed;
            }
        }
    }

}
