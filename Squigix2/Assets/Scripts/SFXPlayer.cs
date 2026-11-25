using UnityEngine;

public static class SFXPlayer
{
    public static AudioClipDatabase database;
    public static void PlaySFX(AudioSource audio)
    {
        audio.Play();
    }

    public static void PlaySFX(string audioKey)
    {
        database.Database[audioKey].Play();
    }
}
