using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BeamBehaviour : MonoBehaviour {

    

    Rigidbody2D rbody;

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float maxDist = 10;
    private float cDist = 0;
    private float lastTime;

    [SerializeField]
    private float checkFreq = 0.2f;

	// Use this for initialization
	void Awake ()
    {
        rbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void OnEnable()
    {
        rbody.velocity = speed * (Vector2)transform.forward;
        cDist = 0;
        lastTime = Time.time;
    }

    void CheckDist()
    {

    }

    void OnDistable()
    {
        CancelInvoke();
    }

}
