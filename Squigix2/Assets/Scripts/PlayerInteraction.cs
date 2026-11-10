using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    InputActionReference interact;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        //Subscribing to the space bar press so that we can toggle the light.
        interact.action.started += Toggle;
    }

    private void Interact()
    {

    }
}
