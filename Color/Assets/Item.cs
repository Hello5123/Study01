using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
