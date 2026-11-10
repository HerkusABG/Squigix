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
        MusicChange();
    }
    public void MusicChange()
    {
        Debug.Log("Music is changed");
        Slider musicSlider = SliderList[0].GetComponent<Slider>();
        audioPlayer.ChangeVolume((int)musicSlider.value, (int)musicSlider.maxValue);
    }
}
