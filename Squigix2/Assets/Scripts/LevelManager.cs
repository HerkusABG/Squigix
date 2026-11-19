using UnityEngine;

public class LevelManager : InitComponent
{

    [SerializeField]
    GameObject exitBlockage;

    [SerializeField]
    GameObject exitPortal;
    public override void Initialize()
    {
        ButtonManager.levelManager = this;
    }

    public void RemoveBlockage()
    {
        exitBlockage.SetActive(false);
        exitPortal.SetActive(true);
    }
}
