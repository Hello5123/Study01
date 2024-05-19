using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test02 : MonoBehaviour
{
    [Header("ItemSlot")]
    [SerializeField]
    private GameObject ItemSlot;
    public int Gan = 160;
    public int _verticalSlotCount, _horizontalSlotCount;
    private List<ItemSlotUI> _slotUIList;
    private RectTransform _contentAreaRT;

    public float sizeBlank = 200f;
    private void InitSlots()
    {
        Vector2 beginPos = new Vector2(20, -20);
        Vector2 curPos = beginPos;
        _slotUIList = new List<ItemSlotUI>(_verticalSlotCount * _horizontalSlotCount);

        for (int j = 0; j < _verticalSlotCount; j++)
        {
            for (int i = 0; i < _horizontalSlotCount; i++)
            {
                int slotIndex = (_verticalSlotCount * j) + i;

                var slotRT = CloneSlot();
                slotRT.pivot = new Vector2(0f, 1f);
                slotRT.anchoredPosition = curPos;
                slotRT.gameObject.SetActive(true);
                slotRT.gameObject.name = $"Item Slot [{slotIndex}]";

                //var slotUI = slotRT.GetComponent<ItemSlotUI>();
                //slotUI.SetSlotIndex(slotIndex);
                //_slotUIList.Add(slotUI);
                curPos.x += Gan;
            }
            curPos = beginPos;
            curPos.y -= Gan * (j+1);
        }
    }
    public RectTransform CloneSlot()
    {
        GameObject go = Instantiate(ItemSlot);
        RectTransform rt = go.GetComponent<RectTransform>();
        rt.SetParent(_contentAreaRT);
        return rt;
    }
    private void Start()
    {
        _contentAreaRT = GetComponent<RectTransform>();
        InitSlots();
    }
}
