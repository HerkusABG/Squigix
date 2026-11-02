using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTracker
{
    public static void Level1()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }
}
