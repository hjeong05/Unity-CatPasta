using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferScene : MonoBehaviour {
    public static TransferScene instance;
    public string transferSceneName;
    public GameObject target;
    private Main themain;
    private CameraManager thecamera;
    public Music music;
    public GameObject inven;
    private SaveNLoad saveNload;

    public Image Gotoshop;

    public static bool quitcheck;

    void Start () {
        instance = this;
        quitcheck = false;
        thecamera = FindObjectOfType<CameraManager>();
        themain = FindObjectOfType<Main>();
        music = FindObjectOfType<Music>();
        saveNload = FindObjectOfType<SaveNLoad>();

    }
    public void Save()
    {
        saveNload.CallSave();
        //저장
    }
    public void Load()
    {
        saveNload.CallLoad();
        //로드
    }
    public void CloseApp()
    {
        Application.Quit();
        //종료
    }
  
    public void quit()  // setting 눌러서 포기했을 경우 
    {
        PlayerStat.instance.Day -= 1;
        StopCoroutine(RunTime.instance.DecreseSlider());
       
        if (objmanager.instance.gameObject)
        { Destroy(objmanager.instance.go[objmanager.instance.N]);
            Destroy(objmanager.instance.gameObject);
            if (objmanager.instance.currentItem != null)
                objmanager.instance.carryLocation = null;
            if (objmanager.instance.removeit == true)
            {
                objmanager.instance.removeit = false;
                objmanager.instance.removeVector();
            }
            CustomerSpawn.instance.StopAllCoroutines();
            RunTime.instance.startTime = 250f;
        }
        else
        {
            CustomerSpawn.instance.StopAllCoroutines();
            RunTime.instance.startTime = 250f;
        }

    }
    public void transferDown()      //리턴 버튼 누르면 스타트 씬으로
    {
        SoundManager.instance.MainButtonSound();
        SoundManager.instance.baseMusic();
        music.audio.Stop();
        themain.CurrentSceneName = transferSceneName;
        thecamera.transform.position = new Vector3(-17f,0,-10);
        themain.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

    }
    public void GamebtnDown()   // 게임버튼 누르면 게임씬으로 
    {
        SoundManager.instance.MainButtonSound();
        if (Inventory_k.instance.inventoryitemList.Count <= 0)
        {
            Gotoshop.gameObject.SetActive(true);

        }
        else 
        {
            Time.timeScale = 1f;
            PlayerStat.instance.money = 0;      // 하루 손님, 돈 음식 초기화
            PlayerStat.instance.people = 0;
            PlayerStat.instance.Corder = 0;
            PlayerStat.instance.Oorder = 0;
            PlayerStat.instance.Torder = 0;
            PlayerStat.instance.Day += 1;

            panController.instance.pan1barFilled.fillAmount = 1f;
            panController.instance.pan2barFilled.fillAmount = 1f;
  
            music.backvolume.value = 0.5f;    // 오디오 소리 값 설정
            music.audio.volume = music.backvolume.value;
            RunTime.instance.startTime = 250f;
            music.audio.Play(); // 게임 오디오 시작하기     
            SoundManager.instance.Base.Stop();// 기본 오디오 끄기
            if (!RunTime.instance.coroutineStartedFlag)
            {
                RunTime.instance.StartCoroutine(RunTime.instance.DecreseSlider());  // 런타임 시작      
            }
            CustomerSpawn.instance.StartCoroutine(CustomerSpawn.instance.RandomSpawn());    // 손님 스폰 클래스 시작시키기
            Debug.Log("스폰 완료");
           
            inven.transform.position = new Vector3(21f, -6f, 0);
            inven.transform.localScale = new Vector3(0.008f, 0.008f, 0.008f);
            inven.SetActive(false);

            themain.CurrentSceneName = transferSceneName;
            target.transform.position = new Vector3(14f, 0, -10);
            thecamera.transform.position = new Vector3(18.7f, 0, -10);
            themain.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        }


    }
    public void ShopBtnDown()    //샵 버튼 누르면 샵씬으로
    {
        SoundManager.instance.MainButtonSound();
        themain.CurrentSceneName = transferSceneName;   
        thecamera.transform.position = new Vector3(0f, 0, -10);
        themain.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

        inven.transform.position = new Vector3(-0.07f, 0.88f, -0.057731f);              //인벤토리 이동
        inven.transform.localScale = new Vector3(0.015f, 0.014f, 0.015f);
        inven.SetActive(true);
    }
 
    public void ReceiptDown()
    {
        music.audio.Stop();// 게임 오디오 끄기
        SoundManager.instance.Base.Play();// 기본 오디오 켜기
        themain.CurrentSceneName = transferSceneName;
        CustomerSpawn.instance.StopAllCoroutines();

        target.transform.position = new Vector3(40f, 0, -10);
        thecamera.transform.position = new Vector3(40f, 0, -10);
        themain.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
       
        saveNload.CallSave();   //저장
    }
}
