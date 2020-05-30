using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //이진파일로 만드는 변환기

public class SaveNLoad : MonoBehaviour {

[System.Serializable] 
      //save and load에서 필수적 -> 데이터가 직렬화됨 ex) a // 10110110001 컴퓨터가 읽고쓰기쉽게
    public class Data
    {
        public int day;
        public int totalMoney;
        public int totalPpl;

        public int floor;
        public int wall;
        public int table;

        public List<string> ItemInventory; //id값으로 가져오기
        public List<int> ItemInventoryCnt;

    }

    private PlayerStat playerstat;
    private itemDatabase database;
    private Inventory_k TheInven;
    private PlayerManager theplayer;
    private TableController thetable;
    private basefloorController thefloor;
    private floorController thewall;

    public Data data;


    public void CallSave()
    {
        database = FindObjectOfType<itemDatabase>();
        TheInven = FindObjectOfType<Inventory_k>();
        playerstat = FindObjectOfType<PlayerStat>();
        thetable = FindObjectOfType<TableController>();
        thefloor = FindObjectOfType<basefloorController>();
        thewall = FindObjectOfType<floorController>();

        data.day = playerstat.Day;
        data.totalMoney = playerstat.t_money;
        data.totalPpl = playerstat.t_people;

        data.floor = thefloor.Currentfloor;
        data.wall = thewall.Currentwall;
        data.table = thetable.CurrentTable;

        Debug.Log("기초 데이터 성공");

        data.ItemInventory.Clear(); //저장하고 다시 로드하면 저장한거의 2배가 저장되므로 초기화시킴
        data.ItemInventoryCnt.Clear();

        List<Item> itemList = Inventory_k.instance.inventoryitemList;// TheInven.inventoryitemList;

        for(int i = 0;i< itemList.Count; i++)
        {
            Debug.Log("인벤토리의 아이템 저장 완료 : " + itemList[i].itemID);
            data.ItemInventory.Add(itemList[i].itemID);
            data.ItemInventoryCnt.Add(itemList[i].itemCnt);
        }

        BinaryFormatter bf = new BinaryFormatter(); //변환

              FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");  
     //   FileStream file = File.Create(Application.persistentDataPath + "/SaveFile.dat");

        bf.Serialize(file, data);
        file.Close();

        Debug.Log(Application.dataPath + "의 위치에 저장완료");
    }

    public void CallLoad()
    {
        BinaryFormatter bf = new BinaryFormatter(); //변환

          FileStream file = File.Open(Application.dataPath + "/SaveFile.dat",FileMode.Open);  

    //    FileStream file = File.Open(Application.persistentDataPath + "/SaveFile.dat", FileMode.Open);  
        if (file != null && file.Length > 0) //파일안에 무언가가 있다면
        {
          data = (Data)bf.Deserialize(file);

            database = FindObjectOfType<itemDatabase>();
            TheInven = FindObjectOfType<Inventory_k>();
            playerstat = FindObjectOfType<PlayerStat>();
            thetable = FindObjectOfType<TableController>();
            thefloor = FindObjectOfType<basefloorController>();
            thewall = FindObjectOfType<floorController>();

            playerstat.Day = data.day;
            playerstat.t_money = data.totalMoney;
            playerstat.t_people = data.totalPpl;

            thefloor.Currentfloor = data.floor;
            thewall.Currentwall = data.wall;
            thetable.CurrentTable = data.table;

            List<Item> itemList = Inventory_k.instance.inventoryitemList;

            for (int i = 0;i<data.ItemInventory.Count; i++) //저장된 인벤아이템 개수만큼 반복
            {
                for(int j= 0; j<database.items.Count; j++)
                {
                    if(data.ItemInventory[i] == database.items[j].itemID)
                    {
                        itemList.Add(database.items[j]);
                        Debug.Log("인벤토리 아이템 로드" + database.items[j].itemID);
                        break;
                    }
                }
            }

            for(int i = 0; i< data.ItemInventoryCnt.Count; i++)
            {
                itemList[i].itemCnt = data.ItemInventoryCnt[i];
            }
            Debug.Log("로드 완료");
        }
        else
        {
            Debug.Log("저장된 세이브 파일이 없습니다.");
        }

        file.Close();

    }
    void Start()
    {
    }
 
}
