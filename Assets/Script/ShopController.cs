using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopController : MonoBehaviour {
      public static ShopController instance;

    public GameObject back;
                      
    private SaveNLoad saveNLoad;


    private int[] Ingredient_price = new int[9]; // 9개의 재료가격들

    private int[] Ingredient_cnt = new int[9];

    public Text tomatocnt;
    public Text baconcnt;
    public Text mushroomcnt;
    public Text shrimpcnt;
    public Text musselcnt;
    public Text t_saucecnt;
    public Text c_saucecnt;
    public Text basilcnt;
    public Text pastacnt;


    public bool loaded = false;

    void Start () {
        instance = this;

        Ingredient_cnt[0] = 1;
        Ingredient_cnt[1] = 1;
        Ingredient_cnt[2] = 1;
        Ingredient_cnt[3] = 1;
        Ingredient_cnt[4] = 1;
        Ingredient_cnt[5] = 1;
        Ingredient_cnt[6] = 1;
        Ingredient_cnt[7] = 1;
        Ingredient_cnt[8] = 1;
        
        Ingredient_price[0] = 5; // tomato
        Ingredient_price[1] = 7; // bacon
        Ingredient_price[2] = 7; // mushroom
        Ingredient_price[3] = 6; // shrimp
        Ingredient_price[4] = 8;//mussel
        Ingredient_price[5] = 4;//t_sauce 5개에
        Ingredient_price[6] = 5;//c_sauce 5개에
        Ingredient_price[7] = 3; //basil
        Ingredient_price[8] = 2; //pasta 5개에

    }
    void Update()
    {

    }

    public void BuybtnDown(int i)
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < Ingredient_price[i])
        {

        }
        else
        {
            PlayerStat.instance.t_money -= (Ingredient_cnt[i] * Ingredient_price[i]);
            Debug.Log(PlayerStat.instance.t_money);
        }
    }

    public void tomatobuy()
    {
        BuybtnDown(0);
        tomatocnt.text = "1";
        Inventory_k.instance.GetAnItem("sliced_tomaotP","sliced_tomato", Ingredient_cnt[0]);
        Ingredient_cnt[0] = 1;
    }
    public void baconbuy()
    {

        BuybtnDown(1);
        baconcnt.text = "1";
        Inventory_k.instance.GetAnItem("baconP","bacon",1002, Ingredient_cnt[1]);
        Ingredient_cnt[1] = 1;
    }
    public void mushroombuy()
    {
        BuybtnDown(2);
        mushroomcnt.text = "1";
        Inventory_k.instance.GetAnItem("mushroomP","mushroom",1003, Ingredient_cnt[2]);
        Ingredient_cnt[2] = 1;
    }
    public void shrimpbuy()
    {

        BuybtnDown(3);
        shrimpcnt.text = "1";
        Inventory_k.instance.GetAnItem("shrimpP","shrimp",1004, Ingredient_cnt[3]);
        Ingredient_cnt[3] = 1;
    }
    public void musselbuy()
    {

        BuybtnDown(4);
        musselcnt.text = "1";
        Inventory_k.instance.GetAnItem("musselP","mussel",1005, Ingredient_cnt[4]);
        Ingredient_cnt[4] = 1;
    }
    public void t_saucebuy()
    {

        BuybtnDown(5);
        t_saucecnt.text = "1";
        Inventory_k.instance.GetAnItem("t_sauceP","t_sauce",1006, Ingredient_cnt[5]);
        Ingredient_cnt[5] = 1;
    }
    public void c_saucebuy()
    {

        BuybtnDown(6);
        c_saucecnt.text = "1";
        Inventory_k.instance.GetAnItem("c_sauceP","c_sauce",1007, Ingredient_cnt[6]);
        Ingredient_cnt[6] = 1;
    }
    public void basilbuy()
    {

        BuybtnDown(7);
        basilcnt.text = "1";
        Inventory_k.instance.GetAnItem("basilP","basil",1008, Ingredient_cnt[7]);
        Ingredient_cnt[7] = 1;
    }
    public void pastabuy()
    {
        BuybtnDown(8);
        pastacnt.text = "1";
        Inventory_k.instance.GetAnItem("o_pastaP","o_pasta",1009, Ingredient_cnt[8]);
        Ingredient_cnt[8] = 1;
    }

    public void tomatoUpArrow()
    {
        int i = 0;
         UpArrow(i);
        tomatocnt.text = Ingredient_cnt[i].ToString();
    }
    public void tomatoDownArrow()
    {
        int i = 0;
        DownArrow(i);
        tomatocnt.text = Ingredient_cnt[i].ToString();
    }
    public void baconUpArrow()
    {
        int i = 1;
          UpArrow(i);
        baconcnt.text = Ingredient_cnt[i].ToString();
    }
    public void baconDownArrow()
    {
        int i = 1;
        DownArrow(i);
        baconcnt.text = Ingredient_cnt[i].ToString();
    }
    public void mushroomUpArrow()
    {
        int i = 2;
            UpArrow(i);
        mushroomcnt.text = Ingredient_cnt[i].ToString();
    }
    public void mushroomDownArrow()
    {
        int i = 2;
        DownArrow(i);
        mushroomcnt.text = Ingredient_cnt[i].ToString();
    }
    public void shrimpUpArrow()
    {
        int i = 3;
          UpArrow(i);
        shrimpcnt.text = Ingredient_cnt[i].ToString();
    }
    public void shrimpDownArrow()
    {
        int i = 3;
          DownArrow(i);
        shrimpcnt.text = Ingredient_cnt[i].ToString();
    }
    public void musselUpArrow()
    {
        int i = 4;
        UpArrow(i);
        musselcnt.text = Ingredient_cnt[i].ToString();
    }
    public void musselDownArrow()
    {
        int i = 4;
        DownArrow(i);
        musselcnt.text = Ingredient_cnt[i].ToString();
    }
    public void t_sauceUpArrow()
    {
        int i = 5;
         UpArrow(i);
        t_saucecnt.text = Ingredient_cnt[i].ToString();
    }
    public void t_sauceDownArrow()
    {
        int i = 5;
        DownArrow(i);
        t_saucecnt.text = Ingredient_cnt[i].ToString();
    }
    public void c_sauceUpArrow()
    {
        int i = 6;
         UpArrow(i);
        c_saucecnt.text = Ingredient_cnt[i].ToString();
    }
    public void c_sauceDownArrow()
    {
        int i = 6;
        DownArrow(i);
        c_saucecnt.text = Ingredient_cnt[i].ToString();
    }
    public void basilUpArrow()
    {
        int i = 7;
       UpArrow(i);
        basilcnt.text = Ingredient_cnt[i].ToString();
    }
    public void basilDownArrow()
    {
        int i = 7;
        DownArrow(i);
        basilcnt.text = Ingredient_cnt[i].ToString();
    }
    public void pastaUpArrow()
    {
        int i = 8;

    UpArrow(i);
        pastacnt.text = Ingredient_cnt[i].ToString();
    }
    public void pastaDownArrow()
    {
        int i = 8;
        DownArrow(i);
       
        pastacnt.text = Ingredient_cnt[i].ToString(); 
    }
    private void UpArrow(int i)
    {
        Ingredient_cnt[i]++;
        
    }
    private void DownArrow(int i)
    {
        if (Ingredient_cnt[i] > 0)
        {
            Ingredient_cnt[i] -= 1;
            //Ingredient_cnt[i]--;
        }
        if (Ingredient_cnt[i] < 0){
            Ingredient_cnt[i] = 1;
        }

    }


}
