using UnityEngine;

public class LightStatus
{

    private bool isAwake;
    private LightState CurrentLightState;
    public LightStatus()
    {
        isAwake = false;
        CurrentLightState = LightState.Asleep;
    }

    public void ToggleStatus()
    {
        isAwake = !isAwake;
        
        if(isAwake)
        {
            CurrentLightState = LightState.Awake;
        }
        else
        {
            CurrentLightState = LightState.Asleep;
        }
    }

    public LightState GetStatus()
    {
        return CurrentLightState;
    }

    public void SetStatus(bool status)
    {
        isAwake = status;
    }

    public bool IsLightAwake()
    {
        return isAwake;
    }
}

public enum LightState
{
    Asleep = 0,
    Awake = 1
}
