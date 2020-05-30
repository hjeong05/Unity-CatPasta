using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Sound
{
    public string name; //사운드 이름

    public AudioClip clip;
    private AudioSource source;

    public float Volume;
    public bool loop;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }
}
public class SoundManager : MonoBehaviour {
 //   [SerializeField]
    public Sound[] sounds;

    public AudioClip soundFinishCook;
    public AudioSource FinishCook;

    public AudioClip soundCook;
    public AudioSource Cook;

    public AudioClip soundClick;
    public AudioSource Click;

    public AudioClip BaseSound;
    public AudioSource Base;

    public AudioClip MainBtnSound;
    public AudioSource MainBtn;

    public static SoundManager instance;

    void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }
	// Use this for initialization
	void Start () {
        instance = this;
   /*     for(int i = 0; i<sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("사운드 파일 이름 : " + i + "=" + sounds[i].name);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }*/
	}
	public void FinishCookSound() {

        FinishCook.PlayOneShot(soundFinishCook);
    }
    public void CookSound()
    {
        Cook.PlayOneShot(soundCook);
    }
    public void ClickSound()
    {
        Click.PlayOneShot(soundClick);
    }
    public void baseMusic()
    {
        Base.Play();
    }
    public void MainButtonSound()
    {
        MainBtn.PlayOneShot(MainBtnSound);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
