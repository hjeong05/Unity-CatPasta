using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receipt : MonoBehaviour {


    public Text DayMoney;
    public Text TotalMoney;
    public Text Day;
    public Text baseMoney;
    public Text TP;
    public Text CP;
    public Text OP;
    public Text Onedayppl;
    public Text Totalppl;

	// Use this for initialization
	void Start () {
   //     PlayerStat.instance.t_money += PlayerStat.instance.money;
    //    PlayerStat.instance.t_people += PlayerStat.instance.people;
	}

	//theSaveNLoad.CallSave(); 저장	// Update is called once per frame
	//theSaveNLoad.CallLoad(); 불러오기
        void Update () {
		DayMoney.text = PlayerStat.instance.money.ToString();
        TotalMoney.text = (PlayerStat.instance.t_money).ToString();
        baseMoney.text = (PlayerStat.instance.t_money-PlayerStat.instance.money).ToString();
        TP.text = PlayerStat.instance.Torder.ToString();
        CP.text = PlayerStat.instance.Corder.ToString();
        OP.text = PlayerStat.instance.Oorder.ToString();
        Onedayppl.text = PlayerStat.instance.people.ToString();
        Totalppl.text = (PlayerStat.instance.t_people ).ToString();
        Day.text = PlayerStat.instance.Day.ToString();
     
    }
}
