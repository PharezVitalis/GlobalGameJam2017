using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Satelitte : MonoBehaviour {

    
    private Transform beamOutLocation;
    private Quaternion lookRot;
    private Vector3 diff;
    private ParticleSystem partSys;

    private AudioSource audio;

    private ParticleSystem deathSys;

    private Transform earthPos;

    private GameObject orbit;
   

    [SerializeField]
    private float addedIntensity = 0.3f;
    private Light light;
    float minIntensity;

    void Awake()
    {
        earthPos = GameObject.FindWithTag("Earth").GetComponent<Transform>();
        audio = GetComponent<AudioSource>();


        beamOutLocation = GetChildSpawner();
        partSys = GetComponent<ParticleSystem>();

        deathSys = GetComponentInChildren<ParticleSystem>();
        

        light = GetComponent<Light>();
        minIntensity = light.intensity;
    }

    Transform GetChildSpawner()
    {
        int length = transform.childCount;

        for (int i = 0; i < length; i++)
        {
            Transform current = transform.GetChild(i);
            if (current.gameObject.tag == "SpawnLocation")
            {
                return current;
            }
        }
        return null;
    }

   void OnEnable()
    {
        LevelManager.instance.SatelliteAdded();

        transform.position = earthPos.position;
        transform.rotation = Quaternion.identity;
    }


    public void LookAt(Vector3 targetPos)
    {
         diff = targetPos - transform.position;
        diff.Normalize();

        lookRot = Quaternion.LookRotation(diff, transform.TransformDirection(Vector3.up));

        transform.rotation = new Quaternion(0, 0, lookRot.z, lookRot.w);

    }

    public void BeamCollision(GameObject beam)
    {
        partSys.Play(false);
        BeamBehaviour beamBeh = beam.GetComponent<BeamBehaviour>();


        beam.transform.position = beamOutLocation.position;
        beam.transform.rotation = beamOutLocation.rotation;

        print(beam.transform.eulerAngles);

        beamBeh.ResetRange();
        beamBeh.VelocityReset();
       
       
    }

    IEnumerator LightFlare()
    {
        float maxIntensity = light.intensity + addedIntensity;
        

        while (light.intensity < maxIntensity)
        {
            light.intensity += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        
        while (light.intensity > minIntensity)
        {
            light.intensity -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

    }


    IEnumerator DeathSequence()
    {
        audio.clip = SoundManager.instance.GetSpot("SateliteCrash");
        deathSys.Play();
        audio.Play();

        yield return new WaitForSeconds(deathSys.duration);

        deathSys.Play();

        yield return new WaitForSeconds(deathSys.startLifetime);

        
        gameObject.SetActive(false);
    }

    public void Die()
    {
        StartCoroutine(DeathSequence());
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Obstacle")
        {
            StartCoroutine(DeathSequence());
        }
        else if (c.tag == "Beam")
        {
            BeamCollision(c.gameObject);
        }
    }

    public void PlayInteractParticles()
    {
        partSys.Play(false);
    }

     void OnDisable()
    {
        LevelManager.instance.SatelliteDestroyed();
        StopAllCoroutines();
        light.intensity = minIntensity;
    }

    public void SetOrbit(GameObject obj)
    {
        orbit = obj;
    }

    public GameObject GetOrbit()
    {
        return orbit.transform.parent.gameObject;

    }
	
    

}
