using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Beam")
        {
            c.gameObject.GetComponent<BeamBehaviour>().ReachedGoal();
        }
    }
}
