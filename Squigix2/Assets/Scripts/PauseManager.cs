using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : InitComponent
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

    public override void Initialize()
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
            if (SettingsWindow.activeSelf)
            {
                SettingsWindow.SetActive(false);
                PauseWindow.SetActive(true);
            }
            else
            {
                RootUI.SetActive(false);
                PauseWindow.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
        else
        {
            SFXPlayer.PlaySFX("Pause");
            RootUI.SetActive(true);
            PauseWindow.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        
    }

    public void Continue()
    {
        RootUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
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
