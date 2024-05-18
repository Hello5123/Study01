using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Options")]
    [Range(0, 10)]
    [SerializeField] private int _horizontalSlotCount = 8;  // ���� ���� ����
    [Range(0, 10)]
    [SerializeField] private int _verticalSlotCount = 8;      // ���� ���� ����
    [SerializeField] private float _slotMargin = 8f;          // �� ������ �����¿� ����
    [SerializeField] private float _contentAreaPadding = 20f; // �κ��丮 ������ ���� ����
    [Range(32, 64)]
    [SerializeField] private float _slotSize = 64f;      // �� ������ ũ��

    [Header("Connected Objects")]
    [SerializeField] private RectTransform _contentAreaRT; // ���Ե��� ��ġ�� ����
    [SerializeField] private GameObject _slotUiPrefab;     // ������ ���� ������
}
