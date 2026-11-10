using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class LightManager : MonoBehaviour
{
    //Class used for storing all the relevant information about light.
    //Does NOT handle the activation of interactables.

    //Input class. Activated by space, built-in unity stuff.
    [SerializeField]
    InputActionReference toggle;


    //Physical light object in the scene.
    [SerializeField]
    GameObject Light;

    //Status of the light (ASLEEP or AWAKE). 
    //Extended functionality, but essentially just a boolean.
    LightStatus Status;

    //The lightRadius class used for actual tracking of interactables.
    LightRadius Radius;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        //Subscribing to the space bar press so that we can toggle the light.
        toggle.action.started += Toggle;

        //Creating the lightstatus class
        Status = new LightStatus();

        //Grabbing the light radius and initializing it.
        Radius = GetComponent<LightRadius>();
        Radius.Initialize(5);
    }


    private void Toggle(InputAction.CallbackContext obj)
    {
        //Just toggling the light, pretty straightforward.
        Status.ToggleStatus();
        Light.SetActive(Status.IsLightAwake());
        
        if (!Status.IsLightAwake())
        {
            Radius.TurnOffOutOfDistanceInteractables();
        }
        Radius.enabled = Status.IsLightAwake();
    }
}
