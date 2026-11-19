using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Color individualColor;
    public void Initialize()
    {
        GetComponent<Renderer>().material.color = individualColor;
    }

    public Color GetColor()
    {
        return individualColor;
    }
}
