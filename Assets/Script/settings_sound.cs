using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings_sound : MonoBehaviour {
    public GameObject go;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SettingbtnDown()
    {
        go.SetActive(true);
    }
    public void OkbtnDown()
    {
        go.SetActive(false);
    }

}
