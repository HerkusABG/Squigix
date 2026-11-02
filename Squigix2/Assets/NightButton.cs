using UnityEngine;

public class NightButton : MonoBehaviour
{

    Animator animator;

    public void Initialize()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isPressed", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isPressed", false);
    }
}
