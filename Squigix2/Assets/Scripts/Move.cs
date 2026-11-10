using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{


    //The actual SQUIGIX walking speed
    [SerializeField]
    float playerSpeed;

    //Indicates SQUIGIX's direction of movement (via vector)
    Vector3 moveDirection;

    //Rigidbody reference
    Rigidbody manoRigidbody;

    //Input variable, unity built-in stuff.
    [SerializeField]
    InputActionReference move;


    private void Start()
    {
        manoRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Reading the inputs and applying it as movement force to SQUIGIX
        Vector2 direction = move.action.ReadValue<Vector2>();
        moveDirection = new Vector3(direction.x, 0, direction.y);
    }

    private void FixedUpdate()
    {
        manoRigidbody.AddForce(moveDirection * playerSpeed);
    }
}
