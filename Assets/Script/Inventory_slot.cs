using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_slot : MonoBehaviour {
    public Image icon;
    public GameObject SpIcon;
 //   public Text itemName_text;
    public Text itemCount_text;
    public int num;
  //  public GameObject btn; //반짝반짝


    public void Additem(Item _item)
    {
        num = _item.Num;
 //       itemName_text.text = _item.itemName;
         icon.sprite = _item.itemIcon;
        SpIcon = _item.Spicon;

       // btn.tag("bacon");
      //  btn.text = _item.BtnNum;

        if(Item.iTemType.Ingredient == _item.itemType) //재료인경우에만 개수 뜨게하도록
        {
            if (_item.itemCnt > 0)
                itemCount_text.text = _item.itemCnt.ToString();
            else
                itemCount_text.text = "";
        }        
    }
    public void RemoveItem()
    {
 //       itemName_text.text = "";
        itemCount_text.text = "";
        icon.sprite = null;
 //       Destroy(SpIcon);
    }
  
}
