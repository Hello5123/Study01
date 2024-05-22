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

    // ������ ���� �޼���
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        // �������� �κ��丮���� �����ϴ� ������ ���⿡ �����մϴ�.
    }

    // ������ ��� ��ȯ �޼���
    public List<Item> GetItems()
    {
        return items;
    }

    // ������ �κ��丮 �ʱ�ȭ �޼���
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
