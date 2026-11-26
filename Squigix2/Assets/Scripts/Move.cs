using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.InputSystem;

public class Move : InitComponent
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

    [SerializeField]
    Transform Mesh;

    Quaternion lastRotation;

    Animator animator;

    public override void Initialize()
    {
        manoRigidbody = GetComponent<Rigidbody>();
        ObjectList.SquigixMove = this;

        if(GetComponentInChildren<Animator>() != null)
        {
            // animator.SetBool("isAwake", true);
            animator = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
        //Reading the inputs and applying it as movement force to SQUIGIX
        Vector2 direction = move.action.ReadValue<Vector2>();
        moveDirection = new Vector3(direction.x, 0, direction.y);
        if(direction.x != 0 || direction.y != 0)
        {
            lastRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        Mesh.rotation = lastRotation;
    }

    private void FixedUpdate()
    {

        manoRigidbody.AddForce(moveDirection * playerSpeed);
    }
}
