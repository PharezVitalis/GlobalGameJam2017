using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    [SerializeField]
    private AudioSource ambient;
    [SerializeField]
    private AudioSource launch;
	
	void Start()
    {
        ambient.Play();
        StartCoroutine(PlayLaunchSound());
    }

    private IEnumerator PlayLaunchSound()
    {
        yield return new WaitForSeconds(1.3f);

        launch.Play();

        yield return new WaitForSeconds(1f);

        Application.LoadLevel(1);
    }
}
