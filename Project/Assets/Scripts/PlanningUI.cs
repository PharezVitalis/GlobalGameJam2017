using UnityEngine;
using System.Collections;

public class PlanningUI : MonoBehaviour {

    [SerializeField]
    private GameObject planningBar;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnterPlanMode();
        }
    }

    public void EnterPlayMode()
    {
        InfoBar(true);
    }

    public void EnterPlanMode()
    {
        InfoBar(false);
    }

    // Turns the info bar on the left of the screen on or off.
    public void InfoBar(bool hidePanel)
    {
        if (hidePanel)
            planningBar.SetActive(false);

        else if (!hidePanel)
            planningBar.SetActive(true);
    }


}
