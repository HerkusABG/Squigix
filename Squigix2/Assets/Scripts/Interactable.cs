using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Start()
    {
        StateManager OSM = GetComponent<StateManager>();
        OSM.Initialize();

        NightButton nightButton;
        TryGetComponent<NightButton>(out nightButton);
        if(nightButton != null)
        {
            nightButton.Initialize();
        }
    }
}
