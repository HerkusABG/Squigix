using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    AudioPlayer audioPlayer;

    [SerializeField]
    List<GameObject> SliderList = new List<GameObject>();

    [SerializeField]
    TMP_Dropdown ResolutionDropdown;

    Vector2[] resolutions = {new Vector2(1920,1080), new Vector2(1536, 864), new Vector2(1366, 768)};

    private bool isFullscreenActive;
    

    private void Start()
    {
        isFullscreenActive = true;
        Initialize();
    }

    private void Initialize()
    {
    }

    public void AudioChange(int audioType)
    {
        Slider slider = SliderList[audioType].GetComponent<Slider>();
        audioPlayer.ChangeVolume((int)slider.value, (int)slider.maxValue, (AudioType)audioType);
    }

    public void ToggleWindowedMode()
    {
        //Screen.fullScreen = !Screen.fullScreen;
        isFullscreenActive = !isFullscreenActive;
        Screen.fullScreen = isFullscreenActive;
    }

    public void DropdownActivated()
    {
        Vector2 newResolution = resolutions[ResolutionDropdown.value];
        Screen.SetResolution((int)newResolution.x, (int)newResolution.y, isFullscreenActive);
        //SetResolution(int width, int height, FullScreenMode fullscreenMode, RefreshRate preferredRefreshRate)
        Debug.Log($"Changing the resolution to {newResolution}");
    }
}
