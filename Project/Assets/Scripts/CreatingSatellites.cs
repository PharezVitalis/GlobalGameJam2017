using UnityEngine;
using System.Collections;

public class CreatingSatellites : MonoBehaviour {

    private Vector3 origin;

    private Vector3 mouseClicked;

    private Vector3 difference;

    private float angle;

    private GameObject satellite;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero))
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


            
            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.transform.tag == "PlanetOrbit")
            //    {
            //        Debug.Log("is planet orbit");
            //        FindAngle();
            //    }
            //    else
            //    {
            //        Debug.Log("is not planet orbit");
            //    }
            //}
        }
    }

    void FindAngle()
    {
        float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        Vector3 satPos;

        mouseClicked = Input.mousePosition;
        origin = transform.position;

        print(origin);

        difference = origin - mouseClicked;

        angle = Vector2.Angle(new Vector2(origin.x, origin.y + radius), mouseClicked);

        print(angle);

        satellite = Pooler.current.GetPooled("Satellite");

        
    }

   
}
