using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

    public Slider backvolume;
    public AudioSource audio;

    public Slider Effectvolume;
    public AudioSource effect1;
    public AudioSource effect2;

    public float EffectVol = 1f;

    public float backVol = 0.5f;
    
	// Use this for initialization
	private void Start () {
           backvolume.value = 0f;
        audio.Stop();

        Effectvolume.value = 0.7f;

	}
	
	// Update is called once per frame
	
    public void SoundSlider()
    {
        audio.volume = backvolume.value;
        backVol = backvolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }
    public void EffectSlider()
    {
        effect1.volume = Effectvolume.value;
        effect2.volume = Effectvolume.value;

        EffectVol = Effectvolume.value;
        PlayerPrefs.SetFloat("effectvol", EffectVol);

    }
    void Update () {
        SoundSlider();
        EffectSlider();
	}
}
