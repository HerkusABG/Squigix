using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    GameObject exitBlockage;
    public void Start()
    {
        ButtonManager.levelManager = this;
    }

    public void RemoveBlockage()
    {
        exitBlockage.SetActive(false);
    }
}
