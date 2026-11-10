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
        interact.action.started += Interact;
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if(Vector3.Distance(transform.position, ObjectList.exitPortal.transform.position) <= 5)
        {
            ObjectList.exitPortal.ExecuteExit();
        }
    }

    void OnDestroy()
    {
        interact.action.started -= Interact;
    }
}
