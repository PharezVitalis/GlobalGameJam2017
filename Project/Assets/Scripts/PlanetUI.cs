using UnityEngine;
using System.Collections;

public class PlanetUI : MonoBehaviour {

    [SerializeField]
    private GameObject planetCircle;

    private CreatingSatellites createSat;

    private bool isUIOpen = false;

    private Collider col;

    void Awake()
    {
        col = GetComponent<Collider>();
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if (col.Raycast(ray, out hit, Mathf.Infinity))
    //        {
    //            if (hit.collider.tag == "Planet")
    //            {
    //                ToggleUI();
    //            }
    //            else if (hit.collider.tag != "PlanetOrbit")
    //            {
    //                print("deslect");
    //                ToggleUI();
    //            }
    //        }
            
    //    }
    //}

    public void ToggleUI()
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

    public void SetUIFlag(bool val)
    {
        isUIOpen = val;
    }

}
