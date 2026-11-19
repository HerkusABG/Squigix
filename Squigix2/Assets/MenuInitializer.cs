using UnityEngine;

public class MenuInitializer : MonoBehaviour
{
    void Start()
    {
        InitComponent[] initComponents = FindObjectsByType<InitComponent>();
        foreach (var component in initComponents)
        {
            component.Initialize();
        }
    }
    
}
