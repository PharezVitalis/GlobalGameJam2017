using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] screens = new GameObject[2];


    void Start()
    {
        if (LevelManager.instance.Score < 14)
        {
            screens[1].SetActive(true);
        }
        else if (LevelManager.instance.Score >= 15)
        {
            screens[0].SetActive(true);
        }
    }

    public void QuitToMenu()
    {
        Application.LoadLevel(0);
    }
}
