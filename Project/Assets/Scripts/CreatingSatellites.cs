using UnityEngine;
using System.Collections;

public class CreatingSatellites : MonoBehaviour {

    private Vector3 origin;

    private Vector3 mouseClicked;

    private float angle;

    private GameObject satellite;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "PlanetOrbit")
                {
                    Debug.Log("is planet orbit");
                    FindAngle();
                }
                else
                {
                    Debug.Log("is not planet orbit");
                }
            }
        }
    }

    void FindAngle()
    {
        mouseClicked = Input.mousePosition;

        origin = gameObject.transform.parent.position;

        angle = Vector3.Angle(origin, mouseClicked);

        satellite = Pooler.current.GetPooled("Satellite");
    }
}
