using UnityEngine;
using System.Collections;

public class Satelitte : MonoBehaviour {

    
    private Transform beamOutLocation;
    private Quaternion lookRot;
    private Vector3 diff;
    private ParticleSystem partSys;

    private ParticleSystem deathSys;
   

    [SerializeField]
    private float addedIntensity = 0.3f;
    private Light light;
    float minIntensity;

    void Awake()
    {
        

        beamOutLocation = GetComponentInChildren<Transform>();
        partSys = GetComponent<ParticleSystem>();

        deathSys = GetComponentInChildren<ParticleSystem>();
        

        light = GetComponent<Light>();
        minIntensity = light.intensity;
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
        partSys.Play();

       

        beam.transform.position = beamOutLocation.position;
        beam.transform.rotation = beamOutLocation.rotation;


       
        beam.GetComponent<BeamBehaviour>().ResetRange();
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
        deathSys.Play();

        yield return new WaitForSeconds(deathSys.duration);

        deathSys.Play();

        yield return new WaitForSeconds(deathSys.startLifetime);


        gameObject.SetActive(false);
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


     void OnDisable()
    {

        StopAllCoroutines();
        light.intensity = minIntensity;
    }
	
    

}
