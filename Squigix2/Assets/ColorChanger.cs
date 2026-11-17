using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Color individualColor;
    void Start()
    {
        GetComponent<Renderer>().material.color = individualColor;
    }

    public Color GetColor()
    {
        return individualColor;
    }
}
