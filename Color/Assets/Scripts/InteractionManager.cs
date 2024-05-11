using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Unity.Properties;
using System;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public interface IInteractable
{
    string PopUpUI();
    void PopDownUI();
}
public class InteractionManager : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    private GameObject curInteractableobject;
    private IInteractable curInteractable;

    public TextMeshProUGUI prompText;
    private Camera cam;

    public UnityEvent UnityEvent;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if(Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/ 2, Screen.height/ 2));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if(hit.collider.gameObject != curInteractableobject)
                {
                    curInteractableobject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractableobject = null;
                curInteractable = null;
                if (prompText != null)
                {
                    prompText.gameObject.SetActive(false);
                }
            }
        }
    }
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.PopDownUI();
            curInteractableobject = null;
            curInteractable = null;
            prompText.gameObject.SetActive(false);
        }
    }
    private void SetPromptText()
    {
        prompText.gameObject.SetActive(true);
        prompText.text = string.Format("<b>[E]<b> {0}", curInteractable.PopUpUI());
    }
}
