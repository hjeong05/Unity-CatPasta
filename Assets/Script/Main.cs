using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    static public Main instance;

    public string CurrentSceneName; // transferScenename변수의 값 저장 tranfetScene스크립에있는거
	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
