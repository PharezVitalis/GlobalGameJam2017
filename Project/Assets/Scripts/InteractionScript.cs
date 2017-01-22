using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

    private Collider col;

    [SerializeField]
    private GameObject planet, planetOrbit;

    private PlanetUI planetUI;

    private TutorialText tutorial;
   

    void Start()
    {
        tutorial = GameObject.FindWithTag("TutorialUI").GetComponent<TutorialText>();
        col = GetComponent<Collider>();
        planetUI = planet.GetComponent<PlanetUI>();

        tutorial.ShowText(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            if ((hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)))
            {
                if (hit.collider.tag == "Planet")
                {
                    tutorial.ShowText(1);
                    if (hit.collider.gameObject == planet)
                    {
                        hit.collider.gameObject.GetComponent<PlanetUI>().ToggleUI();

                        planet = null;
                    }
                    else if (planet == null)
                    {
                        planet = hit.collider.gameObject;

                        hit.collider.gameObject.GetComponent<PlanetUI>().ToggleUI();
                    }
                    else
                    {
                        planet.GetComponent<PlanetUI>().ToggleUI();

                        hit.collider.gameObject.GetComponent<PlanetUI>().ToggleUI();

                        planet = hit.collider.gameObject;
                    }



                    

                }
                else if (hit.collider.tag != "PlanetOrbit" && planet != null)
                {
                    print("toggle off");
                    planet.GetComponent<PlanetUI>().ToggleUI();

                    planet = null;
                    
                }
            }

        }
    }
}
