using UnityEngine;

public class StateManager : MonoBehaviour
{
    public void ExecuteAwake()
    {
        Debug.Log("Entering awake status");
    }

    public void ExecuteAsleep()
    {
        Debug.Log("Entering asleep status");
    }
}
