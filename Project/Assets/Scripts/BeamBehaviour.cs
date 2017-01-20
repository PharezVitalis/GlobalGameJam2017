using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BeamBehaviour : MonoBehaviour {

    

    Rigidbody2D rbody;

    [SerializeField]
    private float speed = 5;

	// Use this for initialization
	void Awake ()
    {
        rbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void OnEnable()
    {
        rbody.velocity = speed * (Vector2)transform.forward;
    }
}
