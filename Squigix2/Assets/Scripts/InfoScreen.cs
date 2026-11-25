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
    private List<Coroutine> Coroutines = new List<Coroutine>();  

    public override void Initialize()
    {
        InfoScreenPrint("Use the WASD keys to move.");
        ObjectList.infoScreen = this;

        skipTextInput.action.started += HideInfoScreen;

        flavourText.color = new Color(flavourText.color.r, flavourText.color.g, flavourText.color.b, 0);
    }

    public void PrintFlavour(string inputText)
    {
        flavourText.text = inputText;
        StartCoroutine(Interpolator.BlendCoroutine(0.01f, 0.2f, flavourText, true));
        StartCoroutine(WaitAndHide(0.01f, 0.4f, flavourText));
    }

    public void InfoScreenPrint(string inputText)
    {
        infoText.text = inputText;
        StopSelectCoroutines();
        Coroutine imageCoroutine = StartCoroutine(Interpolator.BlendCoroutine(0.01f, 0.75f, infoScreenImage, true));
        Coroutine infoTextCoroutine = StartCoroutine(Interpolator.BlendCoroutine(0.01f, 0.75f, infoText, true));
        Coroutine skipTextCoroutine = StartCoroutine(SkipText());

        Coroutines.Add(imageCoroutine);
        Coroutines.Add(infoTextCoroutine);
        Coroutines.Add(skipTextCoroutine);
    }

    private void HideInfoScreen(InputAction.CallbackContext obj)
    {
        StopSelectCoroutines();
        infoScreenImage.color = new Color(infoScreenImage.color.r, infoScreenImage.color.g, infoScreenImage.color.b, 0);
        infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, 0);
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 0);
    }
    

    private IEnumerator SkipText()
    {
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 0);
        yield return new WaitForSeconds(3);

        Coroutine skipTextCoroutine = StartCoroutine(Interpolator.BlendCoroutine(0.01f, 0.3f, skipText, true));
        Coroutines.Add(skipTextCoroutine);
    }

    private IEnumerator WaitAndHide(float waitLength, float fullLength, TextMeshProUGUI textMesh)
    {
        yield return new WaitForSeconds(3);
        textMesh.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 1);

        StartCoroutine(Interpolator.BlendCoroutine(waitLength, fullLength, textMesh, false));
    }

    private void StopSelectCoroutines()
    {
        foreach(Coroutine coroutine in Coroutines)
        {
            StopCoroutine(coroutine);
        }
        Coroutines.Clear();
    }

    void OnDestroy()
    {
        skipTextInput.action.started -= HideInfoScreen;
    }

}