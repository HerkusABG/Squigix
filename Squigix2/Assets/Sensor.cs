using UnityEngine;

public class Sensor : MonoBehaviour
{
    private bool isAwake;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        ObjectList.Sensors.Add(this);
    }


    public void SetSensorStatus(bool inputStatus)
    {
        if(inputStatus == true)
        {
            isAwake = true;
        }
        else
        {
            isAwake = false;
        }
    }
}
