using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panController : MonoBehaviour {
    public static panController instance = null;

    public bool FoodSpawnCheck = true;
    public int pastanum;

    public List<int> IngredientNum = new List<int>();

    public GameObject pan1barBackground;
    public Image pan1barFilled;

    public GameObject pan2barBackground;
    public Image pan2barFilled;

    public GameObject tomatopasta;
    public GameObject creampasta;
    public GameObject oilpasta;

    private bool pan1Cook;
    private bool pan2Cook;

    public List<int> Tpasta = new List<int>();
    private bool tpasta;

    public List<int> Cpasta = new List<int>();
    private bool cpasta;

    public List<int> Opasta = new List<int>();
    private bool opasta;

    private bool coroutineStartedFlag = false;

    // Use this for initialization
    void Start () {
        IngredientNum.Clear();

        tpasta = false;
        cpasta = false;
        opasta = false;

        pan1Cook = false;
        pan2Cook = false;

        Tpasta.Add(1001);
        Tpasta.Add(1004);
        Tpasta.Add(1006);
        Tpasta.Add(1008);
        Tpasta.Add(1009);

        Cpasta.Add(1003);
        Cpasta.Add(1005);
        Cpasta.Add(1007);
        Cpasta.Add(1008);
        Cpasta.Add(1009);

        Opasta.Add(1002);
        Opasta.Add(1003);
        Opasta.Add(1008);
        Opasta.Add(1009);

        pan2barFilled.fillAmount = 1f;
        pan1barFilled.fillAmount = 1f;
     
        instance = this;
      
    }
	
    IEnumerator cooking()
    {
      coroutineStartedFlag = true;

        while (true)
        {
            if (PlayerManager.whichpan == 1 && pan1Cook)
            {
                if (PlayerStat.instance.Day < 5)
                {
                    pan1barFilled.fillAmount -= 0.2f;   // 5초 씩 줄어듬
                }
                else if (PlayerStat.instance.Day>=5 && PlayerStat.instance.Day <10)
                {
                    pan1barFilled.fillAmount -= 0.25f;   // 4초 씩 줄어듬
                }
                else
                {
                    pan1barFilled.fillAmount -= 0.3f;
                }
              
            }
            if(PlayerManager.whichpan == 2 && pan2Cook)
            {
                if (PlayerStat.instance.Day < 5)
                {
                    pan2barFilled.fillAmount -= 0.2f;   // 5초 씩 줄어듬
                }
                else if (PlayerStat.instance.Day >= 5 && PlayerStat.instance.Day < 10)
                {
                    pan2barFilled.fillAmount -= 0.25f;   // 4초 씩 줄어듬
                }
                else
                {
                    pan2barFilled.fillAmount -= 0.3f;
                }
            }
            yield return new WaitForSeconds(1f);

        }
     coroutineStartedFlag = false;
    }
    void Update()
    {
       
        if (pan1barFilled.fillAmount <= 0f) // 팬1 바 끝나면
        {
           
            StopCoroutine(cooking());
            pan1Cook = false;
               // 코루틴 멈추고
            checkPasta();   //파스타 종류 찾기
            if (FoodSpawnCheck)
            {
             
                FoodSpawnCheck = false;
                SpawnPasta();     // 스폰 하기 1번만
                enabled = false;
            }
            else
            {
                enabled = true;
                FoodSpawnCheck = true;

            } SoundManager.instance.Cook.Stop();
           
        }
        if(pan2barFilled.fillAmount <= 0f)// 팬2 바 끝나면
        {     
            StopCoroutine(cooking());
            pan2Cook = false;
            checkPasta();
            if (FoodSpawnCheck)
            {
     
                FoodSpawnCheck = false;
                SpawnPasta();
                enabled = false;
            }
            else
            {
                enabled = true;
                FoodSpawnCheck = true;
     
            }
              SoundManager.instance.Cook.Stop();
        }

    }
 
 bool isTpasta()// 만드려는게 토마토파스타인지
    {
        IngredientNum.Sort();
        if (IngredientNum.Count != Tpasta.Count) return false;
        for( int i = 0; i<IngredientNum.Count; i++)
        {
            if(Tpasta.IndexOf(IngredientNum[i]) == -1)
            {
                return false;
            }
        }
        return true;
    }

    bool isCpasta()// 만드려는게 크림파스타인지
    {
        IngredientNum.Sort();
        if (IngredientNum.Count != Cpasta.Count) return false;
        for (int i = 0; i < IngredientNum.Count; i++)
        {
            if (Cpasta.IndexOf(IngredientNum[i]) == -1)
            {
                return false;
            }
        }
        return true;
    }
    bool isOpasta() // 만드려는게 오일파스타인지
    {
        IngredientNum.Sort();
        if (IngredientNum.Count != Opasta.Count) return false;
        for (int i = 0; i < IngredientNum.Count; i++)
        {
            if (Opasta.IndexOf(IngredientNum[i]) == -1)
            {
                return false;
            }
        }
        return true;
    }
    void checkPasta()   // 어느파스타가 만들어질 건지 체크
    {
        cpasta = isCpasta();
        tpasta = isTpasta();
        opasta = isOpasta();
  
        Debug.Log("tpasta = " + tpasta);
        Debug.Log("cpasta = " + cpasta);
        Debug.Log("opasta = " + opasta);
    }

    public void SpawnPasta()
    {
        SoundManager.instance.FinishCookSound();
        if (tpasta == true)
        {
            if (PlayerManager.whichpan == 1)
                Instantiate(tomatopasta, new Vector3(21.9f, -8.0f, 1f), Quaternion.identity);
            else if (PlayerManager.whichpan == 2)
                Instantiate(tomatopasta, new Vector3(20.3f, -8.0f, 1f), Quaternion.identity);
            tpasta = false;
            pastanum = 1;
            bincontrol.instance.cancel();
            IngredientNum.Clear();
        }
        if (cpasta == true)
        {
            if (PlayerManager.whichpan == 1)
                Instantiate(creampasta, new Vector3(21.9f, -7.8f, 1f), Quaternion.identity);
            else if (PlayerManager.whichpan == 2)
                Instantiate(creampasta, new Vector3(20.3f, -7.8f, 1f), Quaternion.identity);
            cpasta = false;
            pastanum = 2;
            bincontrol.instance.cancel();
            IngredientNum.Clear();
        }
        if (opasta == true)
        {
            if (PlayerManager.whichpan == 1)
                Instantiate(oilpasta, new Vector3(21.9f, -7.8f, 1f), Quaternion.identity);
            else if (PlayerManager.whichpan == 2)
                Instantiate(oilpasta, new Vector3(20.3f, -7.8f, 1f), Quaternion.identity);
            opasta = false;
            pastanum = 3;
            bincontrol.instance.cancel();
            IngredientNum.Clear();
        }
        pastanum = 0;
        pan1barFilled.fillAmount = 1f;
        pan2barFilled.fillAmount = 1f;
    }

    public void pan1btnDown()
    {
        SoundManager.instance.Cook.Play();
        SoundManager.instance.ClickSound();
        enabled = true;
        pan1Cook = true;
        pan1barFilled.fillAmount = 1f; // 이미 채워져 있음.
        pan1barBackground.SetActive(true);
        if (!coroutineStartedFlag)
        {
           
            StartCoroutine(cooking());
        }
    }

    public void pan2btnDown()
    {
        SoundManager.instance.Cook.Play();
        SoundManager.instance.ClickSound();
        pan2Cook = true;
        enabled = true;
        pan2barFilled.fillAmount = 1f; // 이미 채워져 있음
        pan2barBackground.SetActive(true);
        if (!coroutineStartedFlag)
        {
            StartCoroutine(cooking());
        }

    }
}
