using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    float horizontal;
    float vertical;
    private Camera eyes;

    void Start()
    {
        eyes = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Watch();
    }

    private void Watch()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * mouseX);
        eyes.transform.Rotate(Vector3.left * mouseY);
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
