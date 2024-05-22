using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public void ChangeAmount(int num)
    {

    }
    public void HighLight(bool flash)
    {
        if (flash == true)
        {
            gameObject.SetActive(true);
        }
    }
    public void ChangeImage(Sprite Asprite)
    {
        GameObject.Find("Item").GetComponent<Image>().sprite = Asprite;
        
    }
}
