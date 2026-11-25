using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LevelEnd : InitComponent
{
    [SerializeField]
    Image panel;

    [SerializeField]
    GameObject levelCompleteScreen;

    public override void Initialize()
    {
        levelCompleteScreen.SetActive(false);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
    }

    public void LoadLevelEnd()
    {
        StartCoroutine(LevelEndCoroutine());
    }

    private IEnumerator LevelEndCoroutine()
    {
        StartCoroutine(Interpolator.BlendCoroutine(0.01f, 0.4f, panel, true));

        yield return new WaitForSeconds(0.8f);

        levelCompleteScreen.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneTracker.Menu();
    }

    public void Replay()
    {
        SceneTracker.Level1();
    }
}
