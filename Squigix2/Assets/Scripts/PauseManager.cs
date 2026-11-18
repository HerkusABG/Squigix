using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{

    [SerializeField]
    GameObject RootUI;

    [SerializeField]
    GameObject SettingsWindow;

    [SerializeField]
    InputActionReference escape;

    private void Start()
    {
        //Subscribing to the space bar press so that we can toggle the light.
        escape.action.started += Pause;
    }

    private void Pause(InputAction.CallbackContext obj)
    {
        RootUI.SetActive(true);
    }

    public void Continue()
    {
        RootUI.SetActive(false);
    }

    public void Settings()
    {
        SettingsWindow.SetActive(true);
    }

    public void ExitSettings()
    {
        SettingsWindow.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneTracker.Menu();
    }
}
