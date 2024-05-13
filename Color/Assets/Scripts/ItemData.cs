using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "New item")]
public class ItemData : ScriptableObject 
{
    public string Name;
    public int Id;
    public Sprite itemImage;

    [Multiline]
    public string Description;
    GameObject Prefab;
}
