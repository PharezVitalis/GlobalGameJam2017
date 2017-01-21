using UnityEngine;
using System.Collections;

public class PlanetUI : MonoBehaviour {

    [SerializeField]
    private GameObject planetCircle;

    private CreatingSatellites createSat;

    private bool isUIOpen = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform.tag == "Planet")
                {
                    ToggleUI();
                }
            }
        }
    }

    void ToggleUI()
    {
        if (isUIOpen == true)
        {
            planetCircle.SetActive(false);
            isUIOpen = false;
        }
        else if (isUIOpen == false)
        {
            planetCircle.SetActive(true);
            isUIOpen = true;
        }
    }

}
