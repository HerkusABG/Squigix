using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    AudioSource musicSource;
    void Start()
    {
        musicSource.Play();
        Debug.Log(musicSource.volume);
    }

    public void ChangeVolume(int input, int maxValue)
    {
        float final = ((float)input / (float)maxValue);
        musicSource.volume = final;
    }
}
