using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : MonoBehaviour
{
    Vector2 inputVector, moveVector;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        moveVector.x = inputVector.x;
        moveVector.y = inputVector.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
