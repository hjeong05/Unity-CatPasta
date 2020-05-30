using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 벽지 스프라이트 변경하는 스크립트 (초반에 이름을 잘 못 지음 )

[System.Serializable]
public class floorController : MonoBehaviour {

    private int[] wall_price = new int[6];

    public Text money;
    //  private Vector3 wall_pos = new Vector3(18.7f,8.3f,-0.10f );
    public Sprite CurrentSprite;    // 현재 벽이미지
    public Sprite Wsprite1;
    public Sprite Wsprite2;
    public Sprite Wsprite3;
    public Sprite Wsprite4;
    public Sprite Wsprite5;

    public Button apply1;
    public Button apply2;
    public Button apply3;
    public Button apply4;
    public Button apply5;

    public int Currentwall;
  //  public int money;

    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
        wall_price[0] = 200;
        wall_price[1] = 300;
        wall_price[2] = 400;
        wall_price[3] = 500;
        wall_price[4] = 600;

    }
	void Update()
    {
        if (Currentwall == 1)
        {
            spriteRenderer.sprite = Wsprite1;
            apply1.gameObject.SetActive(true);
        }
        else if (Currentwall == 2)
        {
            spriteRenderer.sprite = Wsprite2;
            apply2.gameObject.SetActive(true);
        }
        else if (Currentwall == 3)
        {
            spriteRenderer.sprite = Wsprite3;
            apply3.gameObject.SetActive(true);
        }
        else if (Currentwall == 4)
        {
            spriteRenderer.sprite = Wsprite4;
            apply4.gameObject.SetActive(true);
        }
        else if (Currentwall == 5)
        {
            spriteRenderer.sprite = Wsprite5;
            apply5.gameObject.SetActive(true);

        }
    }
    public void applywall1()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Wsprite1;
        Currentwall = 1;
    }
    public void applywall2()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Wsprite2;
        Currentwall = 2;
    }
    public void applywall3()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Wsprite3;
        Currentwall = 3;
    }
    public void applywall4()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Wsprite4;
        Currentwall = 4;
    }
    public void applywall5()
    {
        SoundManager.instance.MainButtonSound();
        spriteRenderer.sprite = Wsprite5;
        Currentwall = 5;
    }
    public void buywall1()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < wall_price[0])
        {
            apply1.gameObject.SetActive(false);
        }
        else
        {
            apply1.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= wall_price[0];
        }

    }
    public void buywall2()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < wall_price[1])
        {
            apply2.gameObject.SetActive(false);
        }
        else
        {
            apply2.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= wall_price[1];
 
        }
    }
    public void buywall3()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < wall_price[2])
        {
            apply3.gameObject.SetActive(false);
        }
        else
        {
            apply3.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= wall_price[2];
      
        }
    }
    public void buywall4()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < wall_price[3])
        {
            apply4.gameObject.SetActive(false);
        }
        else
        {
            apply4.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= wall_price[3];
      
        }
    }
    public void buywall5()
    {
        SoundManager.instance.ClickSound();
        if (PlayerStat.instance.t_money < wall_price[4])
        {
            apply5.gameObject.SetActive(false);
        }
        else
        {
            apply5.gameObject.SetActive(true);
            PlayerStat.instance.t_money -= wall_price[4];
   
        }
    }

}
