using UnityEngine;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour
{
    private static ItemInventory instance;
    bool isopen = false;
    public GameObject _bag;

    public static ItemInventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ItemInventory>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("ItemInventory");
                    instance = obj.AddComponent<ItemInventory>();
                }
            }
            return instance;
        }
    }

    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        UpdateInventoryUI();
    }

    // 아이템 제거 메서드
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        // 아이템을 인벤토리에서 제거하는 로직을 여기에 구현합니다.
    }

    // 아이템 목록 반환 메서드
    public List<Item> GetItems()
    {
        return items;
    }

    // 아이템 인벤토리 초기화 메서드
    public void ClearInventory()
    {
        items.Clear();
    }
    void UpdateInventoryUI()
    {
        if (isopen && items != null && items.Count > 0)
        {
            GameObject.Find($"Item Slot [0]").GetComponentInChildren<ItemSlot>().ChangeImage(items[0].itemData.itemImage);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isopen = !isopen;
            _bag.SetActive(isopen);
            UpdateInventoryUI();
        }
    }
}
