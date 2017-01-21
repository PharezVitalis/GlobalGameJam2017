using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

    private Collider col;

    void Start()
    {
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (col.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Planet")
                {
                    
                }
                else if (hit.collider.tag != "PlanetOrbit")
                {
                   
                    
                }
            }

        }
    }
}
