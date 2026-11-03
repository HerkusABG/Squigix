using UnityEngine;

public class NightButton : MonoBehaviour
{

    Animator animator;

    StateManager stateManager;

    [SerializeField]
    public int id;

    [HideInInspector]
    public bool isPressed;

    [HideInInspector]
    public bool isLocked;

    public void Initialize()
    {
        animator = GetComponent<Animator>();
        stateManager = GetComponent<StateManager>();
        ButtonManager.AddNightButton(this);
        isPressed = false;
        isLocked = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(stateManager.GetState())
        {
            ButtonManager.ButtonPressed(id);
            animator.SetBool("isPressed", true);
            isPressed = true;
            ButtonManager.PrintButtonStatuses();
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
    }
}
