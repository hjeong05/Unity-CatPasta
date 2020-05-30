using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_k : MonoBehaviour
{

    public static Inventory_k instance = null; // 인스턴스 화 

    private itemDatabase database;

    public Inventory_slot[] slots; //인벤토리 슬롯

    public List<Item> inventoryitemList; //소지한 아이템 리스트
    public List<Item> inventoryTabList; //선택한 탭에 따라 다르게 보여질 아이템 리스트
                                         // Use this for initialization
    public Text Description_text; // 재료이름 설명

    public Transform tf; //grid_slot 밑에있는 자식개체르 ㄹ전부 inventoryslot에 넣을거임

    public GameObject go; //인벤토리 활성화 비활성화
                          //selectedTabimage 색넣을거
    private int selelctedItem; //선택된 아이템

    private bool stopKeyinput; //키입력 제한 ex 1을 사용하고 싶으면 누르고 질의가 뜰때 다른 방향키 제어할때 사용
    private bool preventExec; //중복실행 제한

    void Start()
    {
        instance = this;
        database = FindObjectOfType<itemDatabase>();
        inventoryitemList = new List<Item>();
        inventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<Inventory_slot>(); //girdslot자식개체들이 모두slots에 들어감

    }
public void RemoveAnItem( string _itemId)
{
        for (int i = 0; i < inventoryitemList.Count; i++) // 인벤토리에서 아이템 검색
        {
            if (_itemId == inventoryitemList[i].itemID )// 인벤에서 아이템 발견
            {
                if (inventoryitemList[i].itemCnt > 1) // 아이템이 2개 이상 존재 시 -> 1 감소
                    inventoryitemList[i].itemCnt--;
                else
                    inventoryitemList.RemoveAt(i); // 1개 있으면 인벤에서 삭제
                    ShowItem();
                break;
            }

        }
}
    public void GetAnItem(string _Spid,string _itemID,int num, int _count = 1)
    {
        for (int i = 0; i < database.items.Count; i++) //데이터베이스 아이템 검색
        {
            if (_itemID == database.items[i].itemID) // 데이터베이스에 아이템 발견
            {
                for (int j = 0; j < inventoryitemList.Count; j++) // 인벤에 같은 아이템있는지 확인
                {
                    if (inventoryitemList[j].itemID == _itemID) // 이미 아이템이 존재 -> 개수만 추가
                    {
                        if (inventoryitemList[j].itemType == Item.iTemType.Ingredient)
                        {
                            inventoryitemList[j].itemCnt += _count;
                            // return;
                        }
                        else
                        {
                            inventoryitemList.Add(database.items[i]);
                        }
                        return;
         
                    }
                }
                inventoryitemList.Add(database.items[i]); // 인벤에 해당 아이템 추가
                inventoryitemList[inventoryitemList.Count-1].itemCnt = _count;
              
                return;
            }
        }
        Debug.Log("뗴이터베이스에 해당 ID를 가진 아이템 존재하지 않음"); // 데이터베이스에 없음.
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }

    }  //인벤토리 슬롯 초기화
    public void ShowTab()
    {
        RemoveSlot();
    }
    public void ShowItem()
    {
        inventoryTabList.Clear();
        RemoveSlot();
        //인벤토리는 재료만 보이게 한다.
        for (int i = 0; i < inventoryitemList.Count; i++)
        {

            inventoryTabList.Add(inventoryitemList[i]);
        }  //아이템을 인벤토리 탭 리스트에 추가

        for (int i = 0; i < inventoryitemList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryTabList[i]);
            //     SelectedItem();
        } //아이템활성화
    }
    void Update()
    {
        go.SetActive(true);
        ShowItem();
    }
}


