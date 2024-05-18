using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUITest : MonoBehaviour
{
    [Header("ItemSlot")]
    [SerializeField]
    private GameObject ItemSlot;

    public int Gan= 40;
    public int _verticalSlotCount, _horizontalSlotCount;
    private List<ItemSlotUI> _slotUIList;
    private RectTransform _contentAreaRT;

    public float _slotMargin = 8f;
    public float _slotSize = 64f;

    private void Start()
    {
        InitSlots();
    }

    private void InitSlots()
    {
        ItemSlot.TryGetComponent(out RectTransform slotRect);
        slotRect.sizeDelta = new Vector2(150, 150);
        ItemSlot.TryGetComponent(out ItemSlotUI itemSlotUI);
        if(itemSlotUI == null)  ItemSlot.AddComponent<ItemSlotUI>();
        ItemSlot.SetActive(false);

        Vector2 beginPos = new Vector2(20, 20);
        Vector2 curPos = beginPos;

        _slotUIList = new List<ItemSlotUI>(_verticalSlotCount * _horizontalSlotCount);

        for (int j = 0; j < _verticalSlotCount; j++)
        {
            for (int i = 0; i < _horizontalSlotCount; i++)
            {
                int slotIndex = (_horizontalSlotCount * j) + i;

                var slotRT = CloneSlot();
                slotRT.pivot = new Vector2(0f, 1f); // Left Top
                slotRT.anchoredPosition = curPos;
                slotRT.gameObject.SetActive(true);
                slotRT.gameObject.name = $"Item Slot [{slotIndex}]";

                var slotUI = slotRT.GetComponent<ItemSlotUI>();
                slotUI.SetSlotIndex(slotIndex);
                _slotUIList.Add(slotUI);

                // Next X
                curPos.x += (_slotMargin + _slotSize);
            }

            // Next Line
            curPos.x = beginPos.x;
            curPos.y -= (_slotMargin + _slotSize);
        }
    }
    RectTransform CloneSlot()
    {
        GameObject slotGo = Instantiate(ItemSlot);
        RectTransform rt = slotGo.GetComponent<RectTransform>();
        rt.SetParent(_contentAreaRT);

        return rt;
    }
}
