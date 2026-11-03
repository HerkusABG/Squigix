using UnityEngine;

public class NightButton : MonoBehaviour
{

    Animator animator;

    StateManager stateManager;

    [SerializeField]
    public int id;

    [HideInInspector]
    public bool isPressed;

    public void Initialize()
    {
        animator = GetComponent<Animator>();
        stateManager = GetComponent<StateManager>();
        ButtonManager.AddNightButton(this);
        isPressed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(stateManager.GetState())
        {
            animator.SetBool("isPressed", true);
            isPressed = true;
            ButtonManager.ButtonPressed(id);
            ButtonManager.PrintButtonStatuses();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //animator.SetBool("isPressed", false);
    }
}
