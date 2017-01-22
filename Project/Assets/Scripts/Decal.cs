using UnityEngine;
using System.Collections;

public class Decal : MonoBehaviour {

    public float timeOut = 10;
    bool started = false; // bool used to skip first initialisation
    
    public SpriteRenderer rend;

    // Use this for initialization

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

	void OnEnable()
    {
        if (started)
        {
            // decal is moved so that it is on the surface of the item.
            Vector3 newPos = new Vector2(Mathf.Sign(transform.localScale.x) * 0.5f * rend.bounds.size.x,0);
           

            transform.position += newPos;
            StartCoroutine(FadeOut());
        }
        else
        {
            started = true;
        }
    }
	// Update is called once per frame

    
   

IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeOut / 10);
        Color rendColor = rend.color;
        

        

        while (rendColor.a >0)
        {
            rendColor.a -= Time.deltaTime / timeOut;
            rend.color = rendColor;

            yield return new WaitForFixedUpdate();
        }


        rendColor.a = 1;
        rend.color = rendColor;

        gameObject.SetActive(false);

        

    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
