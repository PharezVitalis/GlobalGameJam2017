using UnityEngine;
using System.Collections;

public class CreatingSatellites : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField]
    private AudioClip[] clip;

    private Vector2 origin;

    private Vector2 mouseClicked;

    private Vector2 difference;

    private float angle;

    private GameObject satellite;

    private GameObject ring;

    private TutorialText tutorial;

    void Awake()
    {
        tutorial = GameObject.FindWithTag("TutorialUI").GetComponent<TutorialText>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if ((hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)))
            {
                if (hit.transform.tag == "PlanetOrbit")
                {
                    tutorial.ShowText(2);
                    int satNum = transform.parent.gameObject.GetComponent<PlanetUI>().GetSatNum();

                    if (satNum < 3)
                    {
                        ring = gameObject;
                        transform.parent.gameObject.GetComponent<PlanetUI>().SetSatNum(1);
                        FindPos();
                    }
                    else if (satNum >= 3)
                    {
                        audio.clip = clip[1];
                        audio.Play();
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        audio.clip = clip[0];
        audio.Play();
    }

    void FindPos()
    {
        float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        Vector2 satPos;

        mouseClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        origin = transform.position;

        Vector2 distanceToClick = origin - mouseClicked;
        distanceToClick.Normalize();
        satPos = (distanceToClick * -radius / 2) + ((Vector2) transform.position);



        

        satellite = Pooler.current.GetPooled("Satellite");

        satellite.SetActive(true);

        satellite.GetComponent<Satelitte>().SetOrbit(ring);

        satellite.GetComponent<FromToMovement>().GoToPoint(satPos);
    
    }
}
