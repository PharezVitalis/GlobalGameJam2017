using UnityEngine;
using System.Collections;

public class SatTest : MonoBehaviour {
    public Transform target;

	// Use this for initialization
	void Start () {
        GetComponent<FromToMovement>().GoToPoint(target.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
