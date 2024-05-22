using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    public UnityAction unityAction;
    public void PickUp()
    {
        gameObject.SetActive(false);
    }

    public void PopDownUI()
    {
        ItemInventory.Instance.AddItem(this);
        Destroy(gameObject);
    }

    public string PopUpUI()
    {
        return string.Format("Pick Up: {0}", itemData.Name);
    }
}
