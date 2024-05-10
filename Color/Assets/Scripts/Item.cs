using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData ItemData;
    public void PickUp()
    {
        gameObject.SetActive(false);
    }

    public void PopDownUI()
    {
        Destroy(gameObject);
    }

    public string PopUpUI()
    {
        return string.Format("Pick Up: {}", ItemData.Name);
    }
}
