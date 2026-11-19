using UnityEngine;

public class Interactable : InitComponent
{
    public override void Initialize()
    {
        StateManager OSM = GetComponent<StateManager>();
        OSM.Initialize();

        NightButton nightButton;
        TryGetComponent<NightButton>(out nightButton);
        if(nightButton != null)
        {
            nightButton.Initialize();
        }
        Sensor sensor = GetComponentInChildren<Sensor>();
        if(sensor != null)
        {
            sensor.Initialize();
        }
        else
        {
            sensor = GetComponent<Sensor>();
            if (sensor != null)
            {
                sensor.Initialize();
            }
            else
            {
                Debug.Log("Sensor was NULL!!");
            }
        }
    }
}
