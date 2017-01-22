using UnityEngine;
using System.Collections;

public class PlanetUI : MonoBehaviour {

    [SerializeField]
    private GameObject planetCircle;

    private CreatingSatellites createSat;

    private bool isUIOpen = false;

    private int satNum = 0;

    private Collider col;

    void Awake()
    {
        col = GetComponent<Collider>();
    }

   
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

    public int GetSatNum()
    {
        return satNum;
    }

    public void SetSatNum(int val)
    {
        satNum += val;
    }

}
