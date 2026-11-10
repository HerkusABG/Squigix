using UnityEngine;

public class StateManager : MonoBehaviour
{
    //Storing references to objects or components
    //which need to be affected by the awake/asleep switch.
    [SerializeField]
    GameObject AnimatedObject;
    Animator animator;

    [SerializeField]
    GameObject ColourObject;

    [SerializeField]
    Color buttonColour;

    //boolean for tracking whether the interactable is awake.
    [HideInInspector]
    bool isAwake;



    public void Initialize()
    {
        //Grabbing the animator, entering asleep state.
        animator = AnimatedObject.GetComponent<Animator>();
        ExecuteAsleep();
    }
    public void ExecuteAwake()
    {
        //Handling the logic relevant to being awoken.
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
        //Handling the logic relevant to being asleep.
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

    //State management methods. Changing the boolean's value or grabbing it.
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
