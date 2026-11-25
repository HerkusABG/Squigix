using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField]
    ExitPortal exitPortal;
    void Start()
    {
        exitPortal.UniqueInitialize();

        ButtonManager.NightButtons.Clear();

        InitComponent[] initComponents = FindObjectsByType<InitComponent>();
        foreach (var component in initComponents)
        {
            component.Initialize();
        }
    }

}
