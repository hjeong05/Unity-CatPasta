using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bincontrol : MonoBehaviour
{
    public static bincontrol instance = null;

    public GameObject[] Ingredients = new GameObject[9];

    public Transform baconobj;
    public Transform sliced_tomatoobj;
    public Transform musselobj;
    public Transform basilobj;
    public Transform mushroomobj;
    public Transform c_pastaobj;
    public Transform t_pastaobj;
    public Transform o_pastaobj;
    public Transform shrimpobj;

    // Use this for initialization
    private string _itemNum;

    GameObject btn;
    void Start()
    {
        instance = this;

    }
    void Update()
    {
    }
    private GameObject findIngredient(int num)
    {
        if (num == 1001)
            return Ingredients[0];
        else if (num == 1002)
            return Ingredients[1];
        else if (num == 1003)
            return Ingredients[2];
        else if (num == 1004)
            return Ingredients[3];
        else if (num == 1005)
            return Ingredients[4];
        else if (num == 1006)
            return Ingredients[5];
        else if (num == 1007)
            return Ingredients[6];
        else if (num == 1008)
            return Ingredients[7];
        else if (num == 1009)
            return Ingredients[8];
        else
            return null;
    }
    private void putIngredient(int i)
    {
        int num = Inventory_k.instance.inventoryitemList[i].Num;//inventoryitemList[i].Num;    // 선택한 슬롯아이템 번호 num에 저장 
    
        if (PlayerManager.whichpan == 1)
        {
            float x = Random.Range(21.8f, 22.1f);
            float y = Random.Range(-8.4f, -9.0f);
 
            Instantiate(findIngredient(num), new Vector3(x, y, 0f), Quaternion.identity);
            Inventory_k.instance.RemoveAnItem(Inventory_k.instance.inventoryTabList[i].itemID);
            panController.instance.IngredientNum.Add(num);
        }
        else if (PlayerManager.whichpan == 2)
        {
            float x = Random.Range(20.2f, 20.4f);
            float y = Random.Range(-8.4f, -9.0f);
  
            Instantiate(findIngredient(num), new Vector3(x, y, 0f), Quaternion.identity);
            Inventory_k.instance.RemoveAnItem(Inventory_k.instance.inventoryTabList[i].itemID);
            panController.instance.IngredientNum.Add(num);
        }
    }
  
   public void btn0Down()
    {
        putIngredient(0);
        SoundManager.instance.ClickSound();
    }
    public void btn1Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(1);
    }
    public void btn2Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(2);
    }
    public void btn3Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(3);
    }
    public void btn4Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(4);
    }
    public void btn5Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(5);
    }
    public void btn6Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(6);  
    }
    public void btn7Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(7);
    }
    public void btn8Down()
    {
        SoundManager.instance.ClickSound();
        putIngredient(8);
    }

    public void cancel()    // 팬에 넣은 재료를 없애기 위해 
    {
        for(int i  = 0;i < panController.instance.IngredientNum.Count; i++)
        {
            GameObject gameObject = GameObject.FindWithTag(panController.instance.IngredientNum[i].ToString());
            if (gameObject)
            {
                Destroy(gameObject);
            }
            else
                return;          

        }
        panController.instance.IngredientNum.Clear();
    }
}
