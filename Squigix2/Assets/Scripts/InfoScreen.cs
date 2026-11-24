using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InfoScreen : InitComponent
{
    [SerializeField]
    Image infoScreenImage;
    [SerializeField]
    TextMeshProUGUI infoText;

    [SerializeField]
    TextMeshProUGUI skipText;

    [SerializeField]
    TextMeshProUGUI flavourText;

    [SerializeField]
    InputActionReference skipTextInput;

    public override void Initialize()
    {
        InfoScreenPrint("Use the WASD keys to move.");
        ObjectList.infoScreen = this;

        skipTextInput.action.started += HideInfoScreen;
    }

    public void PrintFlavour(string inputText)
    {
        flavourText.text = inputText;
        StopAllCoroutines();
        //StartCoroutine(BlendCoroutine(0.01f, flavourText));
    }

    public void InfoScreenPrint(string inputText)
    {
        infoText.text = inputText;
        StopAllCoroutines();
        StartCoroutine(BlendCoroutine(0.01f, 0.75f, infoScreenImage, true));
        StartCoroutine(BlendCoroutine(0.01f, 0.75f, infoText, true));
        StartCoroutine(SkipText());
    }

    private void HideInfoScreen(InputAction.CallbackContext obj)
    {
        //infoText.text = "Closing";
        StopAllCoroutines();
        infoScreenImage.color = new Color(infoScreenImage.color.r, infoScreenImage.color.g, infoScreenImage.color.b, 0);
        infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, 0);
        //StartCoroutine(BlendCoroutine(0.01f, 0.1f, infoScreenImage, false));
        //StartCoroutine(BlendCoroutine(0.01f, 0.1f, infoText, false));
    }
    private IEnumerator BlendCoroutine(float waitLength, float fullLength, Image inputImage, bool fadingIn)
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
        Color imageColor = infoScreenImage.color;

        while (timePassed < 1)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, (timePassed / sequenceLegth));
            inputImage.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return new WaitForSeconds(waitLength);
            timePassed += waitLength;
        }
    }

    private IEnumerator BlendCoroutine(float waitLength, float fullLength, TextMeshProUGUI textMesh, bool fadingIn)
    {
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);

        int startAlpha;
        int endAlpha;

        if(fadingIn)
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

        Color imageColor = infoScreenImage.color;

        while (timePassed <= sequenceLegth)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, (timePassed / sequenceLegth));
            textMesh.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return new WaitForSeconds(waitLength);
            timePassed += waitLength;
        }
    }

    private IEnumerator SkipText()
    {
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 0);
        yield return new WaitForSeconds(3);

        StartCoroutine(BlendCoroutine(0.01f, 0.3f, skipText, true));
    }

    void OnDestroy()
    {
        skipTextInput.action.started -= HideInfoScreen;
    }

}