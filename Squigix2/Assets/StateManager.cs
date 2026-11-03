using UnityEngine;

public class StateManager : MonoBehaviour
{

    [SerializeField]
    GameObject AnimatedObject;
    Animator animator;

    [SerializeField]
    GameObject ColourObject;

    [SerializeField]
    Color buttonColour;

    [HideInInspector]
    bool isAwake;

    public void Initialize()
    {
        animator = AnimatedObject.GetComponent<Animator>();
        ExecuteAsleep();
    }
    public void ExecuteAwake()
    {
        SetState(true);

        if (animator != null)
        {
            animator.SetBool("isAwake", true);
        }
        if(ColourObject != null)
        {
            ColourObject.GetComponent<MeshRenderer>().material.color = Color.white;
            
        }
    }

    public void ExecuteAsleep()
    {
        SetState(false);

        if(animator != null)
        {
            animator.SetBool("isAwake", false);
        }
        if (ColourObject != null)
        {
            ColourObject.GetComponent<MeshRenderer>().material.color = buttonColour;
        }
    }

    public void ToggleState()
    {
        isAwake = !isAwake;
    }

    public void SetState(bool state)
    {
        isAwake = state;
    }

    public bool GetState()
    {
        return isAwake;
    }

}
