using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Interpolator
{
    public static IEnumerator BlendCoroutine(float waitLength, float fullLength, Image inputImage, bool fadingIn)
    {
        inputImage.color = new Color(inputImage.color.r, inputImage.color.g, inputImage.color.b, 0);

        int startAlpha;
        int endAlpha;

        if (fadingIn)
        {
            startAlpha = 0;
            endAlpha = 1;
        }
        else
        {
            startAlpha = 1;
            endAlpha = 0;
        }

        float sequenceLegth = fullLength;

        float timePassed = 0;
        Color imageColor = inputImage.color;

        while (timePassed < 1)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, (timePassed / sequenceLegth));
            inputImage.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return new WaitForSeconds(waitLength);
            timePassed += waitLength;
        }
    }

    public static IEnumerator BlendCoroutine(float waitLength, float fullLength, TextMeshProUGUI textMesh, bool fadingIn)
    {
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);

        int startAlpha;
        int endAlpha;

        if (fadingIn)
        {
            startAlpha = 0;
            endAlpha = 1;
        }
        else
        {
            startAlpha = 1;
            endAlpha = 0;
        }

        float sequenceLegth = fullLength;

        float timePassed = 0;

        Color imageColor = textMesh.color;

        while (timePassed <= sequenceLegth)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, (timePassed / sequenceLegth));
            textMesh.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return new WaitForSeconds(waitLength);
            timePassed += waitLength;
        }
    }
}
