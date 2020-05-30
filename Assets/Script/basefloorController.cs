using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 이 스크립트는 바닥 스프라이트를 변경시키는 스크립트입니다.
[System.Serializable]
public class basefloorController : MonoBehaviour {
   

    private int[] floor_price = new int[7];

    public Sprite CurrentFSprite;    // 현재 바닥이미지
    public Sprite Fsprite1;
    public Sprite Fsprite2;
    public Sprite Fsprite3;
    public Sprite Fsprite4;
    public Sprite Fsprite5;
    public Sprite Fsprite6;

    public Button apply1;
    public Button apply2;
    public Button apply3;
    public Button apply4;
    public Button apply5;
    public Button apply6;

    public int Currentfloor;
    private SpriteRenderer spriteRenderer;
 
    // Use this for initialization
    void Start()
    {   
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = CurrentFSprite;
        floor_price[0] = 100;
        floor_price[1] = 170;
        floor_price[2] = 250;
        floor_price[3] = 320;
        floor_price[4] = 400;
        floor_price[5] = 450;

    }
    void Update()
    {
        if (Currentfloor == 1)
        {
            spriteRenderer.sprite = Fsprite1;
            apply1.gameObject.SetActive(true);
        }
        else if (Currentfloor == 2)
        {
            spriteRenderer.sprite = Fsprite2;
            apply2.gameObject.SetActive(true);
        }
        else if (Currentfloor == 3)
        {
            spriteRenderer.sprite = Fsprite3;
            apply3.gameObject.SetActive(true);
        }
        else if (Currentfloor == 4)
        {
            spriteRenderer.sprite = Fsprite4;
            apply4.gameObject.SetActive(true);
        }
        else if (Currentfloor == 5)
        {
            spriteRenderer.sprite = Fsprite5;
            apply5.gameObject.SetActive(true);
        }
        else if (Currentfloor == 6)
        {
            spriteRenderer.sprite = Fsprite6;
            apply6.gameObject.SetActive(true);
        }
    }
    public void applyfloor1()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Fsprite1;
        Currentfloor = 1;
    }
    public void applyfloor2()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Fsprite2;
        Currentfloor = 2;
    }
    public void applyfloor3()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Fsprite3;
        Currentfloor = 3;
    }
    public void applyfloor4()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Fsprite4;
        Currentfloor = 4;
    }
    public void applyfloor5()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Fsprite5;
        Currentfloor = 5;
    }
    public void applyfloor6()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Fsprite6;
        Currentfloor = 6;
    }
    public void buyfloor1()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < floor_price[0])
        {
            apply1.gameObject.SetActive(false);
        }
        else
        {
            apply1.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= floor_price[0];
     
        }
   
    }
    public void buyfloor2()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < floor_price[1])
        {
            apply2.gameObject.SetActive(false);
        }
        else
        {
            apply2.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= floor_price[1];
 
        }
    }
    public void buyfloor3()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < floor_price[2])
        {
            apply3.gameObject.SetActive(false);
        }
        else
        {
            apply3.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= floor_price[2];
  
        }
    }
    public void buyfloor4()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < floor_price[3])
        {
            apply4.gameObject.SetActive(false);            
        }
        else
        {
            apply4.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= floor_price[3];
     
        }
    }
    public void buyfloor5()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < floor_price[4])
        {
            apply5.gameObject.SetActive(false);
        }
        else
        {
            apply5.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= floor_price[4];
      
        }
    }
    public void buyfloor6()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < floor_price[5])
        {
            apply6.gameObject.SetActive(false);
        }
        else
        {
            apply6.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= floor_price[5];
        }
    }
  
}
