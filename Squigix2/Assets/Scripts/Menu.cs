using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject CreditsWindow;
    public void Play()
    {
        SceneTracker.Level1();
    }

    public void Settings()
    {
        Debug.Log("SETTINGS");
    }

    public void Credits()
    {
        Debug.Log("CREDITS");
        CreditsWindow.SetActive(true);
    }

    public void ExitCredits()
    {
        CreditsWindow.SetActive(false);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
