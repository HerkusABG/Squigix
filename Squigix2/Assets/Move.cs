using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Move
{
    public bool coyoteBool;
    [HideInInspector]
    public float savedSpeedLimit;


    [SerializeField]
    float playerSpeed;
    [SerializeField]
    float playerJumpStrength;
    [SerializeField]
    float playerSpeedLimit;
    [SerializeField]
    float gravity;
    [SerializeField]
    float gravityDelayValue;


    [SerializeField]
    Vector3 debugVector;
    [SerializeField]
    float debugFloat;


    public bool isGrounded;
    public ReferenceData referenceDataAccess;
    [SerializeField]
    GameObject myCamera;


    [HideInInspector]
    public float horizontalInputFloat, verticalInputFloat;
    float fallTimer;
    float horizontalMovementValue;

    [SerializeField]
    float bhopTimer;
    [SerializeField]
    float bhopMultiplier = 1;

    Coroutine jumpCoroutine;

    public bool canJump;
    public bool canJumpAC;


    Vector3 moveDirection;
    Transform cameraTransform;
    Rigidbody manoRigidbody;
    AreaCheckScript areaCheckAccess;


    public TextMeshProUGUI canJumpText;
    public TextMeshProUGUI coyoteText;
    public TextMeshProUGUI isGroundedText;

    private void Start()
    {
        savedSpeedLimit = playerSpeedLimit;
        fallTimer = 0;
        bhopTimer = 0;
        cameraTransform = referenceDataAccess.cameraReference;
        canJump = true;
        manoRigidbody = GetComponent<Rigidbody>();
        areaCheckAccess = GetComponent<AreaCheckScript>();
    }
    public void JumpReset()
    {
        if (jumpCoroutine != null)
        {
            StopCoroutine(jumpCoroutine);
        }

        jumpCoroutine = null;
        canJump = true;
    }
    private void GetInputs()
    {
        horizontalInputFloat = Input.GetAxisRaw("Horizontal");
        verticalInputFloat = Input.GetAxisRaw("Vertical");
    }

    private void Update()
    {
        Vector3 debugVelocity = new Vector3(manoRigidbody.linearVelocity.x, 0, manoRigidbody.linearVelocity.z);
        debugFloat = debugVelocity.magnitude;
        debugVector = manoRigidbody.linearVelocity;

        if (Input.GetKey(KeyCode.Space))
        {
            {
                if (canJump && canJumpAC)
                {
                    if ((isGrounded) || (!isGrounded && coyoteBool))
                    {
                        Jump(transform.up);
                    }
                }
            }
        }
        else
        {
            bhopTimer = 0;
            bhopMultiplier = 1;
            playerSpeedLimit = savedSpeedLimit;
        }

        GetInputs();
    }

    void Jump(Vector3 direction)
    {
        canJump = false;
        canJumpAC = false;
        //Invoke("EnableJumping", 0.2f);
        jumpCoroutine = StartCoroutine(EnableJumpingCoroutine());
        manoRigidbody.linearVelocity = new Vector3(manoRigidbody.linearVelocity.x, 0, manoRigidbody.linearVelocity.z);
        manoRigidbody.AddForce((direction) * 10000 * playerJumpStrength, ForceMode.Force);
    }
    private void FixedUpdate()
    {
        {
            MovingVoid();
        }

        SpeedClamping();
        if (!isGrounded)
        {
            fallTimer = fallTimer + Time.fixedDeltaTime;
            float newGravity = -Mathf.Pow(gravity, fallTimer - gravityDelayValue);
            manoRigidbody.linearVelocity += new Vector3(0, newGravity, 0);
            manoRigidbody.linearVelocity = new Vector3(manoRigidbody.linearVelocity.x, Mathf.Clamp(manoRigidbody.linearVelocity.y, -180, 1000), manoRigidbody.linearVelocity.z);
        }
        else
        {
            fallTimer = 0;
        }
    }
    private void MovingVoid()
    {
        moveDirection = (transform.forward * verticalInputFloat + transform.right * horizontalInputFloat).normalized;
        horizontalMovementValue = moveDirection.magnitude;
        moveDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
        manoRigidbody.AddForce(moveDirection * playerSpeed * 1000 * bhopMultiplier, ForceMode.Force);
    }
    private void SpeedClamping()
    {
        Vector3 manoVelocity = new Vector3(manoRigidbody.linearVelocity.x, 0, manoRigidbody.linearVelocity.z);
        if (manoVelocity.magnitude > playerSpeedLimit)
        {
            Vector3 clampedVelocity = manoVelocity.normalized * playerSpeedLimit;
            manoRigidbody.linearVelocity = new Vector3(clampedVelocity.x, manoRigidbody.linearVelocity.y, clampedVelocity.z);
        }
    }

    public void InvokeCoyoteBoolDisable()
    {
        Invoke("CoyoteBoolDisable", 0.2f);
    }
    private void CoyoteBoolDisable()
    {
        coyoteBool = false;
    }

    public IEnumerator DisableCoyoteCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        coyoteBool = false;
    }

    private void DisableJumping()
    {
        canJump = false;
    }
    private void EnableJumping()
    {
        canJump = true;
    }
    private IEnumerator EnableJumpingCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        canJump = true;
        jumpCoroutine = null;

    }
    public void ChangeSpeedLimit(float newSpeedLimit)
    {
        playerSpeedLimit = newSpeedLimit;
    }
}
