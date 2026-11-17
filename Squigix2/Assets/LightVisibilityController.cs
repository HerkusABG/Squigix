
using UnityEngine;

public class LightVisibilityController : MonoBehaviour
{
    [SerializeField] private Light targetLight;
    [SerializeField] private Renderer targetRenderer;

    private MaterialPropertyBlock properties;

    private void Awake()
    {
        properties = new MaterialPropertyBlock();
    }

    private void LateUpdate()
    {
        if (targetLight == null || targetRenderer == null)
            return;

        Debug.Log("Updating flashlight shader");

        targetRenderer.GetPropertyBlock(properties);

        properties.SetVector(
            "_LightPosition",
            targetLight.transform.position
        );

        Debug.Log("Light position: " + targetLight.transform.position);
        Debug.Log("Renderer: " + targetRenderer.name);
        properties.SetVector(
            "_LightDirection",
            targetLight.transform.forward
        );

        properties.SetFloat(
            "_LightRange",
            targetLight.range
        );

        // Convert spotlight angles into cosine values
        float outer = targetLight.spotAngle * 0.5f;

        properties.SetFloat(
            "_OuterAngle",
            Mathf.Cos(outer * Mathf.Deg2Rad)
        );

        // Inner cone is slightly smaller than outer cone
        float inner = outer * 0.8f;

        properties.SetFloat(
            "_InnerAngle",
            Mathf.Cos(inner * Mathf.Deg2Rad)
        );

        targetRenderer.SetPropertyBlock(properties);
    }
}
