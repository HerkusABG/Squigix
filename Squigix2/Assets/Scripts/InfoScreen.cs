using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour
{
    [SerializeField]
    Image infoScreenImage;

    private void Start()
    {
        StartCoroutine(BlendCoroutine());
    }
    private IEnumerator BlendCoroutine()
    {
        int startAlpha = 0;
        int endAlpha = 1;
        float currentAlpha = 0;

        Color imageColor = infoScreenImage.color;

        while (currentAlpha < 1)
        {
            infoScreenImage.color = new Color(imageColor.r, imageColor.g, imageColor.b, currentAlpha);
            currentAlpha += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
