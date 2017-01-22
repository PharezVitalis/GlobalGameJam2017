using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class UI : MonoBehaviour {

    [SerializeField]
    private GameObject scene,interactable, howToPlayScene, nonInteractable, winDialog;

    [SerializeField]
    private string mainSceneName = "MainScene";

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
	
	void Start () {
        scene.SetActive(false);
        

        masterRange = maxMaster - minMaster;
        childRange = maxChild - minChild;
	}
	
	void Launch()
    {
        Application.LoadLevel(mainSceneName);
    }


    void SetSliders()
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

    void AdjustMaster(float rawValue)
    {
        
        mixer.SetFloat("masterVol",(rawValue * masterRange) + minMaster);
    }

    void AdjustAmbience(float rawValue)
    {
        mixer.SetFloat("ambienceVol", (rawValue * childRange) + minChild);
    }

    void AdjustMusic(float rawValue)
    {
        mixer.SetFloat("musicVol", (rawValue * childRange) + minChild);
    }

    void AdjustSfx(float rawValue)
    {
        mixer.SetFloat("fxVol", (rawValue * childRange) + minChild);
    }

}
