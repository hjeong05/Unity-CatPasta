using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TableController : MonoBehaviour {

    private int[] table_price = new int[7];

    public Sprite CurrentSprite;    // 현재 테이블이미지
    public Sprite Tsprite1;
    public Sprite Tsprite2;
    public Sprite Tsprite3;
    public Sprite Tsprite4;
    public Sprite Tsprite5;
    public Sprite Tsprite6;

    public Button apply1;
    public Button apply2;
    public Button apply3;
    public Button apply4;
    public Button apply5;
    public Button apply6;

    public int CurrentTable;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
        table_price[0] = 150;
        table_price[1] = 200;
        table_price[2] = 250;
        table_price[3] = 300;
        table_price[4] = 350;
        table_price[5] = 400;
    }
    void Update()
    {
        if (CurrentTable == 1)
        {
            apply1.gameObject.SetActive(true);
        }
        if (CurrentTable == 2)
        {
            apply2.gameObject.SetActive(true);
        }
         if (CurrentTable == 3)
        {
            apply3.gameObject.SetActive(true);
        }
         if (CurrentTable == 4)
        {
            apply4.gameObject.SetActive(true);
        }
        if (CurrentTable == 5)
        {
            apply5.gameObject.SetActive(true);
        }
        if (CurrentTable == 6)
        {
            apply6.gameObject.SetActive(true);
        }
    }
    public void applyTable1()
    {
        spriteRenderer.sprite = Tsprite1;
        CurrentTable = 1;
    }
    public void applyTable2()
    {
        spriteRenderer.sprite = Tsprite2;
        CurrentTable = 2;
    }
    public void applyTable3()
    {
        spriteRenderer.sprite = Tsprite3;
        CurrentTable = 3;
    }
    public void applyTable4()
    {
        spriteRenderer.sprite = Tsprite4;
        CurrentTable = 4;
    }
    public void applyTable5()
    {
        spriteRenderer.sprite = Tsprite5;
        CurrentTable = 5;
    }
    public void applyTable6()
    {
        spriteRenderer.sprite = Tsprite6;
        CurrentTable = 6;
    }
    public void buyTable1()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < table_price[0])
        {
            apply1.gameObject.SetActive(false);
        }
        else
        {
            apply1.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= table_price[0];
        }

    }
    public void buyTable2()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < table_price[1])
        {
            apply2.gameObject.SetActive(false);
        }
        else
        {
            apply2.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= table_price[1];

        }
    }
    public void buyTable3()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < table_price[2])
        {
            apply3.gameObject.SetActive(false);
        }
        else
        {
            apply3.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= table_price[2];
    
        }
    }
    public void buyTable4()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < table_price[3])
        {
            apply4.gameObject.SetActive(false);
        }
        else
        {
            apply4.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= table_price[3];
   
        }
    }
    public void buyTable5()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < table_price[4])
        {
            apply5.gameObject.SetActive(false);
        }
        else
        {
            apply5.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= table_price[4];
     
        }
    }
    public void buyTable6()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < table_price[5])
        {
            apply6.gameObject.SetActive(false);   
        }
        else
        {
            apply6.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= table_price[5];
        }
    }

}

