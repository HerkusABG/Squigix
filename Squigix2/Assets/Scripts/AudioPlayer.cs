using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    List<AudioSource> AudioList = new List<AudioSource>();
    void Start()
    {
        foreach (AudioSource source in AudioList)
        {
            source.Play();
        }
    }

    public void ChangeVolume(int input, int maxValue, AudioType audioType)
    {
        float final = ((float)input / (float)maxValue);
        if (audioType == AudioType.Music)
        {
            AudioList[(int)audioType].volume = final;
        }
        else if(audioType == AudioType.Ambience)
        {
            AudioList[(int)audioType].volume = final;
        }
        else if (audioType == AudioType.SFX)
        {
            //insert SFX code here
        }
    }
}

public enum AudioType
{
    Music,
    Ambience,
    SFX
}
