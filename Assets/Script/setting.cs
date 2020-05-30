using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour {

    public GameObject soundui;
    public GameObject go; // shop 활성화 비활성화
                          
    public void SettingDown()
    {
        Time.timeScale = 0;
        go.SetActive(true);
    }
    public void ClosebtnDown()
    {
        Time.timeScale = 1f;
        go.SetActive(false);
    }
    public void QuitbtnDown()
    {
        Debug.Log("게임 종료");
    }
    public void SettingbtnDown()
    {
        soundui.SetActive(true);
    }
    public void OkbtnDown()
    {
        soundui.SetActive(false);
    }

}
