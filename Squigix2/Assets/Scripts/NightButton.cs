using UnityEngine;

public class NightButton : InitComponent
{
    Animator animator;
    StateManager stateManager;

    [SerializeField]
    public int id;

    [HideInInspector]
    public bool isPressed;

    [HideInInspector]
    public bool isLocked;

    private MeshCollider meshCollider;

    public new void Initialize()
    {
        animator = GetComponent<Animator>();
        /*if(animator == null)
        {
            Debug.Log("NULL ANIMATOR");
        }*/
        stateManager = GetComponent<StateManager>();
        meshCollider = GetComponentInChildren<MeshCollider>();
        GetComponentInChildren<ColorChanger>().Initialize();
        ButtonManager.AddNightButton(this);
        isPressed = false;
        isLocked = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isLocked || isPressed) return;
        if(stateManager.GetState())
        {
            ButtonPressExecute();
        }
    }

    private void ButtonPressExecute()
    {
        ButtonManager.ButtonPressed(id);
        animator.SetBool("isPressed", true);
        isPressed = true;
        if (meshCollider != null)
        {
            meshCollider.enabled = false;
            Debug.Log("disabling collider");
        }
    }

    public void DistanceBasedToggle()
    {
        if(Vector3.Distance(transform.position, ObjectList.SquigixMove.transform.position) <= 2)
        {
            ButtonPressExecute();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //animator.SetBool("isPressed", false);
    }

    public void ResetButton()
    {
        isPressed = false;
        animator.SetBool("isPressed", false);
        if (meshCollider != null)
        {
            meshCollider.enabled = true;
            Debug.Log("enabling collider");
        }
    }
}
