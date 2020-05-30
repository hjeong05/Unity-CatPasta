using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    static public CameraManager instance;

    public GameObject target;
    private Vector3 targetposition;
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
        if(target.gameObject != null)
        targetposition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
       
    }
}
