using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    
    float displacement;
    int points=0, satellitesInUse=0, satellitesTotal=0;

    [SerializeField]
    float signalFireRate = 1.5f;

    [SerializeField]
    string levelMusicName = "StarWaves", ambienceName = "Void";

    [SerializeField]
    Transform beamSpawnLocation;

   
  

    void Awake()
    {
        if (instance)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        if (IsLevelScene)
        {


            displacement = Vector2.Distance(beamSpawnLocation.position,
                GameObject.FindGameObjectWithTag("Goal").transform.position);
        }
    }

    void OnEnable()
    {

        Invoke("DelayedInitialise", 0.05f);
        


       
        if (IsLevelScene)
        InvokeRepeating("FireSignal", signalFireRate, signalFireRate);
    }


    void DelayedInitialise()
    {
        if (levelMusicName != null)
            SoundManager.instance.PlayMusic(levelMusicName);

        if (ambienceName != null)
            SoundManager.instance.PlayAmbience(ambienceName);
    }

    void FireSignal()
    {
        GameObject beam = Pooler.current.GetPooled("Beam");
       
        if (beam)
        {
            beam.transform.position = beamSpawnLocation.position;
            beam.transform.rotation = beamSpawnLocation.rotation;
            beam.SetActive(true);
        }
        else
        {
            Debug.Log("Beam is empty");
            return;
        }
    }

   
    void OnDisable()
    {
        CancelInvoke();
    }

    public void PuzzleSolved(float distanceTravelled)
    {
        points = Mathf.RoundToInt(displacement) - ((Mathf.RoundToInt(0.2f * (distanceTravelled / displacement)) + satellitesInUse / 2));
    }

    public int Score
    {
        get
        {
            return points;
        }
    }

    public int TotalSatellites
    {
        get
        {
            return satellitesTotal;
        }
    }

    public bool IsLevelScene
    {
        get
        {
            return !(Application.loadedLevel == 0);
        }
    }

    public void SatelliteAdded()
    {
        satellitesInUse++;
        satellitesTotal++;
    }

    public void SatelliteDestroyed()
    {
        satellitesInUse--;
    }

}
