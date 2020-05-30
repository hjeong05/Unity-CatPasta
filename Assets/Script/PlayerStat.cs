using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {

    public static PlayerStat instance; // 다른곳에서 참조할 수 있도록 해놓기

    public int Day; // 몇일차 표시

    public int t_money; //총 금액
    public int money;   //하루 번 돈
    public int t_people;    //누적 손님
    public int people;  // 하루 손님

    public Text OneDaymoney;
    public Text Onedaypeople;

    public Text totalmoney;

    public Text day;

    public int Torder;
    public int Corder;
    public int Oorder;

	// Use this for initialization
	void Start () {
        instance = this;
        t_money = 300; //초기 돈
 
        Day = 0;
        Torder = 0;
        Corder = 0;
        Oorder = 0;

	}

	void Update () {      
        OneDaymoney.text = money.ToString();
        Onedaypeople.text = people.ToString();
        totalmoney.text = t_money.ToString();
        day.text = Day.ToString();
    }
}
