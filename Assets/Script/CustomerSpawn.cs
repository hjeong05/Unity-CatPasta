using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawn : MonoBehaviour {
    public static CustomerSpawn instance;

    public GameObject dog;
    public GameObject penguin;
    public GameObject rabbit1;
    public GameObject rabbit2;
    public GameObject turtle;
    public GameObject lion;

    public Text Xtext;
    public Text Xtext1;
    public Text Xtext2;
    public Text Xtext3;

    public Vector3 vector; // 스폰할 위치 가져오기

    public bool spawnok;
    public bool ok;

    public static List<Vector3> usingplace = new List<Vector3>();
    public static List<Vector3> emptyplace = new List<Vector3>();
    public static List<Vector3> place = new List<Vector3>();

    protected int p;
    public int n;
    public int cnt = 0; // 손님 수 나타내기 위한 변수
    public static int s = 0;

    public GameObject[] go = new GameObject[6]; // 손님 오브젝트 리스트

    public bool coroutineStartedFlag = false;
    // Use this for initialization
    void Start () {

        instance = this;
        ok = true;
        usingplace.Clear();

        place.Add(new Vector3(15.5f, -3.3f, 0f));
        place.Add(new Vector3(22f, -3.3f, 0f));
        place.Add(new Vector3(15.5f, 1.9f, 0));
        place.Add(new Vector3(22f, 1.9f, 0f));
        place.Add(new Vector3(22f, 6.7f, 0f));
        place.Add(new Vector3(15.5f, 6.7f, 0f));

    }
    public IEnumerator RandomSpawn()
    {
        while (true)
        {
            go[0] = dog;
            go[1] = penguin;
            go[2] = rabbit1;
            go[3] = rabbit2;
            go[4] = turtle;
            go[5] = lion;

            n = Random.Range(0, 6);

            if (PlayerStat.instance.Day < 5)
            {
                Xtext.gameObject.SetActive(true);
                Xtext1.gameObject.SetActive(true);
                Xtext2.gameObject.SetActive(true);
                Xtext3.gameObject.SetActive(true);
                p = Random.Range(0, 2);
                vector = place[p];
                if (usingplace.Contains(vector) == true)
                {
                    p = Random.Range(0, 2);
                }
                else if (usingplace.Contains(vector) == false)
                {

                    yield return new WaitForSeconds(Random.Range(10, 13));

                    if (go[n] != null)
                    {
                        go[n] = Instantiate(go[n], vector, Quaternion.identity) as GameObject;

                        usingplace.Add(vector);
                        s += 1;

                        Debug.Log("벡터 더함 " + s);
                    }
                }
            }
            else if (PlayerStat.instance.Day > 4 && PlayerStat.instance.Day < 10)
            {
                Xtext.gameObject.SetActive(true);
                Xtext1.gameObject.SetActive(true);
                Xtext2.gameObject.SetActive(false);
                Xtext3.gameObject.SetActive(false);
                p = Random.Range(0, 4);
                vector = place[p];
                if (usingplace.Contains(vector) == true)
                {
                    p = Random.Range(0, 4);
                }
                else if (usingplace.Contains(vector) == false)
                {
                    yield return new WaitForSeconds(Random.Range(6, 9));

                    if (go[n] != null)
                    {
                        go[n] = Instantiate(go[n], vector, Quaternion.identity) as GameObject;

                        usingplace.Add(vector);
                        s += 1;

                        Debug.Log("벡터 더함 " + s);
                    }
                }
            }
            if (PlayerStat.instance.Day > 9)
            {
                Xtext.gameObject.SetActive(false);
                Xtext1.gameObject.SetActive(false);
                Xtext2.gameObject.SetActive(false);
                Xtext3.gameObject.SetActive(false);

                p = Random.Range(0, 6);
                vector = place[p];

                if (usingplace.Contains(vector) == true)
                {
                    p = Random.Range(0, 6);
                }
                else if (usingplace.Contains(vector) == false)
                {
                    yield return new WaitForSeconds(Random.Range(3, 5));

                    if (go[n] != null)
                    {
                        go[n] = Instantiate(go[n], vector, Quaternion.identity) as GameObject;

                        usingplace.Add(vector);
                        s += 1;

                        Debug.Log("벡터 더함 " + s);
                    }
                }
            }
            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }
}
