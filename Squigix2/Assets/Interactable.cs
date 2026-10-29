using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Start()
    {
        StateManager OSM = GetComponent<StateManager>();
        OSM.Initialize();
    }
}
