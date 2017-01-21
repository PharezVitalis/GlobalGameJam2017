using UnityEngine;
using System.Collections;

public class LeveManager : MonoBehaviour {

    public static LeveManager instance;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }
}
