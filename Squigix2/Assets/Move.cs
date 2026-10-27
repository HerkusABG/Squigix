using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{

    [HideInInspector]
    public float savedSpeedLimit;

    [SerializeField]
    float playerSpeed;
    [SerializeField]
    float playerSpeedLimit;


    [HideInInspector]
    public float horizontalInputFloat, verticalInputFloat;

    Vector3 moveDirection;
    Rigidbody manoRigidbody;

    [SerializeField]
    InputActionReference move;

    [SerializeField]
    InputActionReference toggle;


    private void Start()
    {
        savedSpeedLimit = playerSpeedLimit;
        manoRigidbody = GetComponent<Rigidbody>();

        toggle.action.started += Toggle;
    }

    private void Update()
    {
        //Vector3 debugVelocity = new Vector3(manoRigidbody.linearVelocity.x, 0, manoRigidbody.linearVelocity.z);
        //GetInputs();

        Vector2 direction = move.action.ReadValue<Vector2>();
        moveDirection = new Vector3(direction.x, 0, direction.y);

        manoRigidbody.AddForce(moveDirection * playerSpeed);

        //GetInputs();
    }

    private void GetInputs()
    {
        //horizontalInputFloat = Input.GetAxisRaw("Horizontal");
        //verticalInputFloat = Input.GetAxisRaw("Vertical");


        if (moveDirection.x != 0)
        {
            Debug.Log("X moving");
        }
        if (moveDirection.y != 0)
        {
            Debug.Log("Y moving");
        }
    }

    private void Toggle(InputAction.CallbackContext obj)
    {
        Debug.Log("Toggle");
    }    
}
