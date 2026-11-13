using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    AudioPlayer audioPlayer;

    [SerializeField]
    List<GameObject> SliderList = new List<GameObject>();

    private void Start()
    {
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
}
