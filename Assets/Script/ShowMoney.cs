using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour {
    public Text onedaymoney;
    public Text onedayppl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        onedaymoney.text = PlayerStat.instance.money.ToString();
        onedayppl.text = PlayerStat.instance.people.ToString();
	}
}
