using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startpoint : MonoBehaviour {
    public string startPoint;
    private Main themain;
    private CameraManager thecamera;
	// Use this for initialization
	void Start () {
        themain = FindObjectOfType<Main>();
        thecamera = FindObjectOfType<CameraManager>();

		if(startPoint == themain.CurrentSceneName)
        {
            thecamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            themain.transform.position = this.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
