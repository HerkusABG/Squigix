using UnityEngine;

public class Sensor : MonoBehaviour
{

    private bool isActivated;

    StateManager stateManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        //Making sure the sensor isn't activated.
        isActivated = false;
        //Adding the sensor to the object list for later referencing.
        ObjectList.Sensors.Add(this);
        //Grabbing relevant components.
        stateManager = GetComponentInParent<StateManager>();
    }

    //This gets toggled by the LightRadius
    //Executing the awake/asleep methods from the state manager based on light radius information.
    public void SetSensorStatus(bool inputStatus)
    {
        if(inputStatus == true)
        {
            isActivated = true;
            stateManager.ExecuteAwake();
        }
        else
        {
            isActivated = false;
            stateManager.ExecuteAsleep();
        }
    }

    public bool GetSensorStatus()
    {
        return isActivated;
    }
}
