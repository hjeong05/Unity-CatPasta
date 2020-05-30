using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunTime : MonoBehaviour {
    public static RunTime instance;

    public Slider _runtime;
    public float startTime = 250f;

    public TransferScene transferScene;
    public CustomerSpawn customerSpawn;
    public objmanager objmanager;

    public static bool start;

    public bool coroutineStartedFlag = false;

    // Use this for initialization
    void Start () {

        instance = this;
        transferScene = FindObjectOfType<TransferScene>();
        customerSpawn = FindObjectOfType<CustomerSpawn>();
        objmanager = FindObjectOfType<objmanager>();
        start = true;
        _runtime = gameObject.GetComponent<Slider>();
        _runtime.value = startTime;
        _runtime.minValue = 0f;
        _runtime.maxValue = 250f;

	}
   
    // Update is called once per frame
    void Update() {

        if (_runtime.value <= 0f)
        {

            StopCoroutine(DecreseSlider());
            startTime = 250f;
            if (PlayerManager.instance.currentItem != null)
            {
                PlayerManager.instance.currentItem.parent = null;
                PlayerManager.instance.currentItem = null;
            }
            TransferScene.instance.ReceiptDown();
        }

    }

    public IEnumerator DecreseSlider()
    {
        coroutineStartedFlag = true;
        if(_runtime != null)
        {
            _runtime.value = startTime;
            _runtime.minValue = 0f;
            _runtime.maxValue = 250f;
            while (start)
            {
                startTime -= 1f;
                _runtime.value = startTime;

                yield return new WaitForSeconds(1f);
            }
        }
        coroutineStartedFlag = false;

    }

}

