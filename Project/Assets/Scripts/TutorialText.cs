using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {

    [SerializeField]
    private GameObject[] texts = new GameObject[3];
    private bool[] hasPlayed = new bool[3];

    void Start()
    {
        for (int i = 0; i <= 2; i++)
        {
            hasPlayed[i] = false;
        }
    }

    public void ShowText(int val)
    {
        StopCoroutine("ShowText");
        for (int i = 0; i <= 2; i++)
        {
            texts[i].SetActive(false);
        }

        if (hasPlayed[val] == false)
        {
            texts[val].SetActive(true);

            StartCoroutine(DisplayText(val));

        }   
    }

    IEnumerator DisplayText(int val)
    {
        yield return new WaitForSeconds(5);
        texts[val].SetActive(false);

        hasPlayed[val] = true;
    }
}
