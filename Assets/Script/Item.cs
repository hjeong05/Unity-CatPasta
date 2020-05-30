using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

[System.Serializable]
public class Item {
    public string itemName;         // 아이템의 이름
    public string itemID;              // 아이템의 고유번호
    public string SpID;
 //   public string itemDes;          // 아이템의 설명
    public int itemCnt; // 소지 개수
    public Sprite itemIcon; // 아이템 아이콘
    public iTemType itemType; //아이템 속성 설정
    public int Num;
    public GameObject Spicon;
    
    public enum iTemType // 아이템의 속성 설정에 대한 갯수
    {
        Ingredient,
        Furniture,
        Wall,
        Floor
    }
    //itemID가 스트링이면 스트링문자열로 가지고와야함.
    public Item(string Spid, string id, string name, string desc,int _num,  iTemType type, int cnt = 1)
    {
        // 윗 줄과 같이 모두 연결해줍니다.
        SpID = Spid;
        itemID = id;
        itemName = name;
        itemType = type;
        itemCnt = cnt;
        Num = _num; // 넣은 재료 구분하기위한 숫자

        itemIcon = Resources.Load("items/"+ id.ToString(),typeof(Sprite))as Sprite;
        Spicon = Resources.Load("items/" + Spid.ToString(), typeof(GameObject)) as GameObject;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
