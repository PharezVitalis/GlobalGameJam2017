using UnityEngine;
using System.Collections;

public class Satelitte : MonoBehaviour {

    
    private Transform beamOutLocation;
    private Quaternion lookRot;
    private Vector3 diff;


    void Awake()
    {
        beamOutLocation = GetComponentInChildren<Transform>();
    }

    public void LookAt(Vector3 targetPos)
    {
         diff = targetPos - transform.position;
        diff.Normalize();

        lookRot = Quaternion.LookRotation(diff, transform.TransformDirection(Vector3.up));

        transform.rotation = new Quaternion(0, 0, lookRot.z, lookRot.w);

    }
	
}
