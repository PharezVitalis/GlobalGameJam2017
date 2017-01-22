using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class UI : MonoBehaviour {

    [SerializeField]
    private GameObject interactable, howToPlayScene;

    [SerializeField]
    private string mainSceneName = "Main Scene";

    private GameObject cScene;
    bool h2PlayEnabled = false;
    [SerializeField]
    AudioMixer mixer;

    [SerializeField]
    private float minMaster = -60, maxMaster = 6;
    [SerializeField]
    private float minChild = -55, maxChild = 4;

    [SerializeField]
    float deadSound = -80, dead = 0.05f;

    Text points;
    Text totalSatelittes;

    [SerializeField]
    private Slider masterVolSlider, ambientSlider, fxSlider, musicSlider;

    private float masterRange, childRange;
	


	void Start ()
    {

        masterRange = maxMaster - minMaster;
        childRange = maxChild - minChild;

        SetSliders();
    }
	
	public void Launch()
    {
       
        Application.LoadLevel(1);
    }


    public void SetSliders()
    {
        float value;
        mixer.GetFloat("masterVol", out value);

        value -= minMaster;

        value = value / masterRange;

        masterVolSlider.value = value*masterVolSlider.maxValue;

        mixer.GetFloat("fxVol", out value);
        value -= minChild;
        value = value / childRange;

        fxSlider.value = value*fxSlider.maxValue;

        mixer.GetFloat("musicVol", out value);
        musicSlider.value = ((value - minChild) / childRange)*musicSlider.maxValue;

        mixer.GetFloat("ambienceVol", out value);
        ambientSlider.value = ((value - minChild) / childRange)*ambientSlider.maxValue;
        
    }

    public void AdjustMaster()
    {
        
        mixer.SetFloat("masterVol",(masterVolSlider.value* masterRange) + minMaster);
    }

    public void AdjustAmbience()
    {
        mixer.SetFloat("ambienceVol", (ambientSlider.value * childRange) + minChild);
    }

    public void AdjustMusic()
    {
        mixer.SetFloat("musicVol", (musicSlider.value * childRange) + minChild);
    }

    public void AdjustSfx()
    {
        mixer.SetFloat("fxVol", (fxSlider.value * childRange) + minChild);
    }

}
