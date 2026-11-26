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
        if (database != null)
        {
            database.Database[audioKey].Play(0);
        }
    }

    public static void StopSFX(string audioKey)
    {
        database.Database[audioKey].Stop();
    }
}
