using System.Collections.Generic;
using UnityEngine;

public class AudioClipDatabase : InitComponent
{
    [SerializeField]
    public Dictionary<string, AudioSource> Database
       = new Dictionary<string, AudioSource>
       {
           //{"csv", XlFileFormat.xlCSV},
           //{"html", XlFileFormat.xlHtml}
       };

    public override void Initialize()
    {
        SFXPlayer.database = this;
    }

    public void ChangeSFXVolume(float input)
    {
        foreach(var entry in Database)
        {
            entry.Value.volume = input;
        }
    }
}
