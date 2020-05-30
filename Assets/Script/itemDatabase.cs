using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();
  
	// Use this for initialization
	void Start () {
        //파스타 요리들 
 //       items.Add(new Item("CreamPastaP", "CreamPasta", "Creampasta", "",0));
 //       items.Add(new Item("TomatoPastaP", "TomatoPasta", "Tomatopasta", "", 0));
//        items.Add(new Item("OilPastaP", "OilPasta", "Oilpasta", "", 0));


        items.Add(new Item("sliced_tomatoP","sliced_tomato", "Tomato", "상큼한 토마토",1001, Item.iTemType.Ingredient));
        items.Add(new Item("baconP","bacon", "Bacon", "고소한 베이컨",1002, Item.iTemType.Ingredient));
        items.Add(new Item("mushroomP","mushroom", "Mushroom", "식감이 뛰어난 버섯",1003, Item.iTemType.Ingredient));
        items.Add(new Item("shrimpP","shrimp", "Shrimp", "탱글탱글한 새우",1004, Item.iTemType.Ingredient));
        items.Add(new Item("musselP","mussel", "Mussel", "해감이 잘 된 홍합",1005, Item.iTemType.Ingredient));
        items.Add(new Item("t_pastaP","t_sauce", "Tomato sauce", "가장 기본적인 소스",1006, Item.iTemType.Ingredient));
        items.Add(new Item("c_pastaP","c_sauce", "Cream sauce", "부드럽고 크리미한 소스",1007, Item.iTemType.Ingredient));
        items.Add(new Item("basilP","basil", "Basil", "파스타의 맛을 돋궈주는 바질 허브",1008, Item.iTemType.Ingredient));
        items.Add(new Item("o_pastaP","o_pasta", "Spagetti", "얇고 기다란 파스타 면",1009, Item.iTemType.Ingredient));
      /*   
        items.Add(new Item(20001, "", "아늑한 나무 패턴 바닥", Item.iTemType.Furniture));
        items.Add(new Item(20002, "", "귀여운 땡땡이 패턴 바닥", Item.iTemType.Furniture));
        items.Add(new Item(20003, "", "초록색 마름모 패턴 바닥", Item.iTemType.Furniture));
        items.Add(new Item(20004, "", "북유럽풍 사각 패턴 바닥", Item.iTemType.Furniture));
        items.Add(new Item(20005, "", "고풍스러운 자주색 카펫 바닥", Item.iTemType.Furniture));
        items.Add(new Item(20006, "", "로맨틱한 분위기의 패턴 바닥", Item.iTemType.Furniture));
        */
        items.Add(new Item("floor1P","floor1", "나무패턴", "아늑한 나무 패턴 바닥",2001, Item.iTemType.Floor));
        items.Add(new Item("floor2P", "floor2", "땡땡이패턴", "귀여운 땡땡이 패턴 바닥",2002, Item.iTemType.Floor));
        items.Add(new Item("floor3P", "floor3", "초록색마름모패턴", "초록색 마름모 패턴 바닥",2003, Item.iTemType.Floor));
        items.Add(new Item("floor4P", "floor4", "북유럽사각패턴", "북유럽풍 사각 패턴 바닥",2004, Item.iTemType.Floor));
        items.Add(new Item("floor5P", "floor5", "자주색카펫", "고풍스러운 자주색 카펫 바닥",2005, Item.iTemType.Floor));
        items.Add(new Item("floor6P", "floor6", "로맨틱패턴", "로맨틱한 분위기의 패턴 바닥",2006,Item.iTemType.Floor));

        items.Add(new Item("wall1P","wall1", "갈색포인트벽지", "깔끔한 갈색 포인트의 벽지",3001, Item.iTemType.Wall));
        items.Add(new Item("wall1P", "wall2", "노란줄무니패턴벽지", "노란 줄무니 패턴 벽지",3002, Item.iTemType.Wall));
        items.Add(new Item("wall1P", "wall3", "초록색계열벽지", "자연느낌의 초록색 계열 벽지",3003, Item.iTemType.Wall));
        items.Add(new Item("wall1P", "wall4", "블루포인트벽지", "시원한 블루 포인트의 벽지",3004, Item.iTemType.Wall));
        items.Add(new Item("wall1P", "wall5", "플럼색벽지", "플럼색의 고풍스러운 벽지",3005, Item.iTemType.Wall));
        items.Add(new Item("wall1P", "wall6", "살구색벽지", "달달한 느낌의 살구색 벽지",3006, Item.iTemType.Wall));

    }	
	// Update is called once per frame
	void Update () {
		
	}
}
