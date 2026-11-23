using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : InitComponent
{
    [SerializeField]
    Image infoScreenImage;
    [SerializeField]
    TextMeshProUGUI infoText;

    [SerializeField]
    TextMeshProUGUI skipText;

    public override void Initialize()
    {
        InfoScreenPrint("Infoscreen");
    }

    public void InfoScreenPrint(string inputText)
    {
        infoText.text = inputText;
        StartCoroutine(BlendCoroutine(0.01f, infoScreenImage));
        StartCoroutine(BlendCoroutine(0.01f, infoText));
        StartCoroutine(SkipText());
    }
    private IEnumerator BlendCoroutine(float waitLength, Image inputImage)
    {
        inputImage.color = new Color(inputImage.color.r, inputImage.color.g, inputImage.color.b, 0);

        int startAlpha = 0;
        int endAlpha = 1;
        float timePassed = 0;
        Color imageColor = infoScreenImage.color;

        while (timePassed < 1)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, timePassed);
            inputImage.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return new WaitForSeconds(waitLength);
            timePassed += waitLength;
        }
    }

    private IEnumerator BlendCoroutine(float waitLength, TextMeshProUGUI textMesh)
    {
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);

        int startAlpha = 0;
        int endAlpha = 1;
        float timePassed = 0;

        Color imageColor = infoScreenImage.color;

        while (timePassed < 1)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, timePassed);
            textMesh.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return new WaitForSeconds(waitLength);
            timePassed += waitLength;
        }
    }

    private IEnumerator SkipText()
    {
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 0);
        yield return new WaitForSeconds(3);

        StartCoroutine(BlendCoroutine(0.01f, skipText));
    }

}