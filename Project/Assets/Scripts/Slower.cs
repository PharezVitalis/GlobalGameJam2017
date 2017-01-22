using UnityEngine;
using System.Collections;

public class Slower : MonoBehaviour {

    [SerializeField]
    private float reductionRate = 0.2f;

    public float Rate
    {
        get
        {
            return reductionRate;
        }
    }
	
}
