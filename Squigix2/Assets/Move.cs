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


    private void Start()
    {
        savedSpeedLimit = playerSpeedLimit;
        manoRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 direction = move.action.ReadValue<Vector2>();
        moveDirection = new Vector3(direction.x, 0, direction.y);

        manoRigidbody.AddForce(moveDirection * playerSpeed);
    }
}
