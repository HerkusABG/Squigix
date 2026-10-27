using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference toggle;

    [SerializeField]
    GameObject Light;

    LightStatus Status;

    LightRadius Radius;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        toggle.action.started += Toggle;

        Status = new LightStatus();

        Radius = GetComponent<LightRadius>();
        Radius.Initialize(5);
    }


    private void Toggle(InputAction.CallbackContext obj)
    {
        Status.ToggleStatus();
        Light.SetActive(Status.IsLightAwake());
    }
}
