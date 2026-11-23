using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    [SerializeField]
    InfoScreen infoScreenAccess;

    [SerializeField]
    string tutorialText;

    private void OnTriggerEnter(Collider other)
    {
        infoScreenAccess.InfoScreenPrint(tutorialText);
    }
}
