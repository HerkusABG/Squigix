using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    [SerializeField]
    InfoScreen infoScreenAccess;

    [SerializeField]
    string tutorialText;

    private bool isAlreadyActived = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isAlreadyActived) return;
        infoScreenAccess.InfoScreenPrint(tutorialText);
        isAlreadyActived = true;
    }
}
