using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{

    [SerializeField]
    GameObject RootUI;

    [SerializeField]
    GameObject PauseWindow;

    [SerializeField]
    GameObject SettingsWindow;

    [SerializeField]
    InputActionReference escape;

    private bool isPaused;

    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
        //Subscribing to the space bar press so that we can toggle the light.
        escape.action.started += Pause;
    }

    private void Pause(InputAction.CallbackContext obj)
    {
        if(isPaused)
        {
            RootUI.SetActive(false);
            PauseWindow.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            RootUI.SetActive(true);
            PauseWindow.SetActive(true);
            Time.timeScale = 0;
        }
        isPaused = !isPaused;
    }

    public void Continue()
    {
        RootUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Settings()
    {
        SettingsWindow.SetActive(true);
        PauseWindow.SetActive(false);
    }

    public void ExitSettings()
    {
        SettingsWindow.SetActive(false);
        PauseWindow.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneTracker.Menu();
    }

    void OnDestroy()
    {
        escape.action.started -= Pause;
    }
}
