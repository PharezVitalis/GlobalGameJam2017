using UnityEngine;
using System.Collections;

public class CreatingSatellites : MonoBehaviour
{

    private Vector2 origin;

    private Vector2 mouseClicked;

    private Vector2 difference;

    private float angle;

    private GameObject satellite;

    private GameObject ring;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if ((hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)))
            {
                if (hit.transform.tag == "PlanetOrbit" && transform.parent.gameObject.GetComponent<PlanetUI>().GetSatNum() < 3)
                {
                    ring = gameObject;
                    transform.parent.gameObject.GetComponent<PlanetUI>().SetSatNum(1);
                    FindPos();
                }
            }
        }
    }

    void FindPos()
    {
        float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        Vector2 satPos;

        mouseClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        origin = transform.position;

        Vector2 distanceToClick = origin - mouseClicked;
        distanceToClick.Normalize();
        satPos = (distanceToClick * -radius / 2) + ((Vector2) transform.position);



        

        satellite = Pooler.current.GetPooled("Satellite");

        satellite.SetActive(true);

        satellite.GetComponent<Satelitte>().SetOrbit(ring);

        satellite.GetComponent<FromToMovement>().GoToPoint(satPos);
    
    }

    void CreateSat()
    {

    }
}
