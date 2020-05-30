using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objmanager : MonoBehaviour {
    public static objmanager instance;

    public bool allpplout;

    private bool wait;

    public GameObject waitingbarBackground;
    public Image waitingbarFilled;

    public GameObject eatingbarBackground;
    public Image eatingbarFilled;

    private Animator animator;

    public bool satisfied;
    public bool eat;
    private string istag;

    public GameObject oil_pasta;
    public GameObject cream_pasta;
    public GameObject tomato_pasta;

    public int PastaMoney;

    public bool removeit;

    public GameObject[] go = new GameObject[3]; //pasta oredering randomly

    public int N; // random pick int for pasta

    private bool e_coroutineStartFlag = false;
    private bool w_coroutineStartFlag = false;

    public GameObject carryLocation = null;
    public Transform currentItem = null;

    void OnTriggerEnter2D(Collider2D other)
    {     
        if (PlayerManager.putin == true)
        {
            PlayerManager.instance.currentItem = null;

            currentItem = null;
            if (other.tag == "TomatoPasta" && currentItem == null)
            {

                Debug.Log("touched!!!!");
                currentItem = other.transform;
                carryLocation = other.gameObject;
                currentItem.position = carryLocation.transform.position;

                currentItem.parent = transform;

                waitingbarBackground.SetActive(false);
                StopCoroutine(waiting());
                waitingbarFilled.fillAmount = 1f;
                Destroy(go[N]);
                eatingbarBackground.SetActive(true);
                if (!e_coroutineStartFlag)
                {
                    StartCoroutine(eating());   //먹는 코루틴 시작
                }

                animator.SetBool("StartEat", true);

                carryLocation.tag = "TomatoPasta";
                PlayerStat.instance.Torder += 1;

            }
            else if (other.tag == "CreamPasta" && currentItem == null)
            {
                Debug.Log("touched!!!!");
                currentItem = other.transform;
                carryLocation = other.gameObject;
                currentItem.position = carryLocation.transform.position;

                currentItem.parent = transform;

                waitingbarBackground.SetActive(false);
                StopCoroutine(waiting());
                waitingbarFilled.fillAmount = 1f;
                Destroy(go[N]);
                eatingbarBackground.SetActive(true);
                //    eatingbarFilled.fillAmount = 1f;
                if (!e_coroutineStartFlag)
                {
                    StartCoroutine(eating());   //먹는 코루틴 시작
                }
                animator.SetBool("StartEat", true);

                carryLocation.tag = "CreamPasta";
                PlayerStat.instance.Corder += 1;
            }
            else if (other.tag == "OilPasta" && currentItem == null)
            {
                Debug.Log("touched!!!!");

                currentItem = other.transform;
                carryLocation = other.gameObject;
                currentItem.position = carryLocation.transform.position;
                currentItem.parent = transform;

                waitingbarBackground.SetActive(false);
                StopCoroutine(waiting());
                waitingbarFilled.fillAmount = 1f;
                Destroy(go[N]);
                eatingbarBackground.SetActive(true);

                if (!e_coroutineStartFlag)
                {
                    StartCoroutine(eating());   //먹는 코루틴 시작
                }
                animator.SetBool("StartEat", true);

                carryLocation.tag = "OilPasta";
                PlayerStat.instance.Oorder += 1;
            }
            PlayerManager.putin = false;

        }

    }

    // Use this for initialization
    void Start() {
        instance = this;

        satisfied = false;

        PastaMoney = 50;    // 기본 파스타 값

        removeit = true;
        animator = GetComponent<Animator>();

        wait = true;
        eat = true;
        go[0] = tomato_pasta;
        go[1] = cream_pasta;
        go[2] = oil_pasta;

        go[0].tag = "TomatoPasta";
        go[1].tag = "CreamPasta";
        go[2].tag = "OilPasta";

        pastaOrder();

        waitingbarFilled.fillAmount = 1f; //이미 채워져 있음.
        eatingbarFilled.fillAmount = 1f;

        eatingbarBackground.SetActive(false);

        StartCoroutine(waiting());
    }
    private void MoneyPasta()
    {
        if(PlayerStat.instance.Day < 5)
        {
            PastaMoney = 50;
        }
        else if (PlayerStat.instance.Day < 10 || PlayerStat.instance.Day>=20)
        {
            PastaMoney = 60;
        }
        else if(PlayerStat.instance.Day < 20)
        {
            PastaMoney = 70;
        }
    }
    public IEnumerator waiting()
    {
        w_coroutineStartFlag = true;
        while (wait)
        {
            if(PlayerStat.instance.Day < 5)
            {
                if (gameObject.tag == "lion")   //사자이면
                    waitingbarFilled.fillAmount -= 0.07f; //약 12초 기다림
                else if (gameObject.tag == "turtle") //거북이이면
                    waitingbarFilled.fillAmount -= 0.025f;//40초 기다림
                else if (gameObject.tag == "rabbit" || gameObject.tag == "customer")
                    waitingbarFilled.fillAmount -= 0.05f; //20초 기다림
            }
            else if (PlayerStat.instance.Day < 10 || PlayerStat.instance.Day>= 20)
            {
                if (gameObject.tag == "lion")   //사자이면
                    waitingbarFilled.fillAmount -= 0.1f; 
                else if (gameObject.tag == "turtle") //거북이이면
                    waitingbarFilled.fillAmount -= 0.03f;
                else if (gameObject.tag == "rabbit" || gameObject.tag == "customer")
                    waitingbarFilled.fillAmount -= 0.08f; 
            }
            else if(PlayerStat.instance.Day < 20)
            {
                if (gameObject.tag == "lion")   //사자이면
                    waitingbarFilled.fillAmount -= 0.13f; 
                else if (gameObject.tag == "turtle") //거북이이면
                    waitingbarFilled.fillAmount -= 0.05f;
                else if (gameObject.tag == "rabbit" || gameObject.tag == "customer")
                    waitingbarFilled.fillAmount -= 0.1f; 
            }
            yield return new WaitForSeconds(1f);
        }
        w_coroutineStartFlag = false;
    }

    public IEnumerator eating()
    {
        e_coroutineStartFlag = true;
        while (eat)
        {
            eatingbarFilled.fillAmount -= 0.1f; //10초 기다림
            yield return new WaitForSeconds(1f);
        }
        e_coroutineStartFlag = false;
    }

    void pastaOrder()
    {
        N = Random.Range(0, 3);

        go[N] = Instantiate(go[N],
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2f, gameObject.transform.position.z)
               , Quaternion.identity);
        istag = go[N].tag;
    }

    void check()    // 주문에 맞는 음식을 주었는지 확인
    {
        if (satisfied == false)
        {
            if (carryLocation != null)
            {
                if (carryLocation.tag == istag)
                {
                    if (gameObject.tag == "rabbit")     // 안경토끼일때,
                    {
                        int m = Random.Range(PastaMoney-10, PastaMoney+10);
                        PlayerStat.instance.money += m;
                        PlayerStat.instance.t_money += m;
                        PlayerStat.instance.people += 1;
                        PlayerStat.instance.t_people += 1;
                    }
                    else if (gameObject.tag == "lion")  // 사자일때
                    {
                        PlayerStat.instance.money += PastaMoney*2;
                        PlayerStat.instance.t_money += PastaMoney * 2;
                        PlayerStat.instance.people += 1;
                        PlayerStat.instance.t_people += 1;
                    }
                    else
                    {
                        PlayerStat.instance.money += PastaMoney;
                        PlayerStat.instance.t_money += PastaMoney;
                        PlayerStat.instance.people += 1;
                        PlayerStat.instance.t_people += 1;
                    }       //나머지
                }
                else        //주문에 맞지 않은 음식 주었을 때 
                {
                    PlayerStat.instance.money += PastaMoney/2;
                    PlayerStat.instance.t_money += PastaMoney/2;
                    PlayerStat.instance.people += 1;
                    PlayerStat.instance.t_people += 1;
                }
                satisfied = true; Debug.Log(PlayerStat.instance.people);
            }
        }
    }

    public void removeVector()     // 손님이 나간 테이블 벡터 사용중인 테이블 리스트에서 지우기
    {
        CustomerSpawn.s--;
        CustomerSpawn.usingplace.Remove(gameObject.transform.position);
        Debug.Log("벡터 지움 " + CustomerSpawn.s);
       
    }

    void Update()
    {
        MoneyPasta();   // Day에 따라 매번 값 업데이트 시킴
        if (eatingbarFilled.fillAmount <= 0f)
        {
            check();
            eat = false;

            animator.SetBool("StartEat", false);
            StopCoroutine(waiting());
            waitingbarBackground.SetActive(false);
            StopCoroutine(eating());
            eatingbarBackground.SetActive(false);
            Destroy(carryLocation);

            if (gameObject != null)
            {
                Destroy(this.gameObject, 2f);    // 손님 삭제
 
                if(removeit== true)
                {
                    removeit = false;
                     removeVector();
                }
                if (currentItem != null)
                {
                    currentItem.parent = null;
                    currentItem = null;
                    carryLocation = null;
                }
            }

        }
        if (waitingbarFilled.fillAmount <= 0f)
        {
            wait = false;
            StopCoroutine(waiting());
            waitingbarBackground.SetActive(false);
            StopCoroutine(eating());
            eatingbarBackground.SetActive(false);

            Destroy(carryLocation);

            if (gameObject != null)
            {
                Destroy(this.gameObject, 2f);    // 손님 삭제
                if (removeit == true)
                {
                    removeit = false;
                    removeVector();
                }
                if (currentItem != null)
                {
                    currentItem.parent = null;
                    currentItem = null;
                    carryLocation = null;
                }
                Destroy(go[N]);
                
            }

        }
        if (RunTime.instance._runtime.value <= 0f)  // 하루 시간이 지났을 때 
        {
            Destroy(go[N]);
            if (gameObject != null)
            {
                Destroy(this.gameObject);
                if (currentItem != null)
                    carryLocation = null;
                if (removeit == true)
                {
                    removeit = false;
                    removeVector();
                }
            }
          
        }

    }
}


