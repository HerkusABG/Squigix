using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    GameObject exitBlockage;

    [SerializeField]
    GameObject exitPortal;
    public void Start()
    {
        ButtonManager.levelManager = this;
    }

    public void RemoveBlockage()
    {
        exitBlockage.SetActive(false);
        exitPortal.SetActive(true);
    }
}
