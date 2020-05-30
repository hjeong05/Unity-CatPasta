using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnManager : MonoBehaviour {
    public GameObject inven;



    // Use this for initialization
	void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
		

	}
    public void quit()  // setting 눌러서 포기했을 경우 
    {
        PlayerStat.instance.Day -= 1;

        CustomerSpawn.instance.StopAllCoroutines(); // 손님 스폰 정지
  //      objmanager.instance.StopAllCoroutines();    // 손님 행동 정지

        StopCoroutine(RunTime.instance.DecreseSlider());

        if (objmanager.instance.gameObject != null)
            Destroy(objmanager.instance.gameObject);
        if (objmanager.instance.go[objmanager.instance.N] != null)
            Destroy(objmanager.instance.go[objmanager.instance.N]);
        if (objmanager.instance.carryLocation != null)
            Destroy(objmanager.instance.carryLocation);
        else
            RunTime.instance.startTime = 100f;

    }

}
