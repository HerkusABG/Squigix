using UnityEngine;

public class StateManager : MonoBehaviour
{

    [SerializeField]
    GameObject AnimatedObject;
    Animator animator;

    public void Initialize()
    {
        animator = AnimatedObject.GetComponent<Animator>();
    }
    public void ExecuteAwake()
    {
        Debug.Log("Entering awake status");

        animator.SetBool("isAwake", true);
    }

    public void ExecuteAsleep()
    {
        Debug.Log("Entering asleep status");

        animator.SetBool("isAwake", false);
    }
}
