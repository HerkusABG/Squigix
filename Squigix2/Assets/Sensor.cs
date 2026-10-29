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
        Debug.Log("Created sensor1");
        isActivated = false;
        ObjectList.Sensors.Add(this);
        stateManager = GetComponentInParent<StateManager>();
    }


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
