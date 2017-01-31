using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    [SerializeField]
    private AudioSource ambient;
    [SerializeField]
    private AudioSource launch;

    [SerializeField]
    private float timeoutFromPlay = 2;
    private float timeRemaing;
	
	void Start()
    {
        ambient.Play();
        StartCoroutine(PlayLaunchSound());
    }

    private IEnumerator PlayLaunchSound()
    {
        timeRemaing = timeoutFromPlay;

        yield return new WaitForSeconds(1.3f);

        launch.Play();

        while (timeRemaing > 0)
        {
            timeRemaing -= (Time.fixedDeltaTime / timeoutFromPlay);

            if (timeRemaing < 1.4f)
            {
                launch.volume = timeRemaing / timeoutFromPlay;
                ambient.volume = timeRemaing / timeoutFromPlay;
            }

            yield return new WaitForFixedUpdate();
        }

        Application.LoadLevel(1);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            StopAllCoroutines();

            Application.LoadLevel(1);
        }
    }
}
