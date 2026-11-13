using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject CreditsWindow;

    [SerializeField]
    GameObject SettingsWindow;

    public void Play()
    {
        SceneTracker.Level1();
    }

    public void Settings()
    {
        SettingsWindow.SetActive(true);
    }

    public void Credits()
    {
        CreditsWindow.SetActive(true);
    }

    public void ExitCredits()
    {
        CreditsWindow.SetActive(false);
    }

    public void ExitSettings()
    {
        SettingsWindow.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
