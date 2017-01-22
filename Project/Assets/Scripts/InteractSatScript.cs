using UnityEngine;
using System.Collections;

public class InteractSatScript : MonoBehaviour {

    private bool isRotating = false;

    private Satelitte satScript;

    private Collider col;

    void Awake()
    {
        satScript = gameObject.GetComponent<Satelitte>();
        col = GetComponent<Collider>();
    }
	
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if ((hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)))
            {
                if (hit.collider.tag == "Satellite")
                {
                    satScript = hit.collider.gameObject.GetComponent<Satelitte>();
                    Debug.Log("is satellite (left click)");
                    isRotating = true;

                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if ((hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)))
            {
                if (hit.transform.tag == "Satellite")
                {
                    hit.transform.gameObject.SetActive(false);
                    Debug.Log("is satellite (right click)");
                }
            }
        }

        if (isRotating == true && Input.GetMouseButton(0))
        {
            float d, radius;
            radius = 1.2f;

            // Pythagorus equation to work out if the point exist inside the circle.
            d = Mathf.Pow((transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x), 2.0f) + Mathf.Pow(transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 2.0f);

            d = Mathf.Sqrt(d);

            // If the point clicked is outside of the circle then allow the satellite to point at the mouse.
            // This is due to the sat turning way to fast without a buffer zone.
            if (d > radius)
            {
                satScript.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            } 
        }

        if (isRotating == true && Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }
}
