﻿using UnityEngine;
using System.Collections;

public class CreatingSatellites : MonoBehaviour
{

    private Vector2 origin;

    private Vector2 mouseClicked;

    private Vector2 difference;

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
                    FindPos();
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

    void FindPos()
    {
        float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        Vector2 satPos;

        mouseClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        origin = transform.position;

        Vector2 distanceToClick = origin - mouseClicked;
        distanceToClick.Normalize();
        satPos = distanceToClick * -radius;


        print(satPos);

        satellite = Pooler.current.GetPooled("Satellite");

        
    }

    void CreateSat()
    {

    }
}
