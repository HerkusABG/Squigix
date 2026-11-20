
using System.Collections.Generic;
using UnityEngine;

public class LightVisibilityController : InitComponent
{
    [SerializeField] private Light targetLight;
    [SerializeField] private Renderer targetRenderer;

    [SerializeField]
    private LightManager lightManager;

    private MaterialPropertyBlock properties;

    GameObject[] phosphorusObjects;
    List<Renderer> phosphorusRenderers = new List<Renderer>();

    public override void Initialize()
    {
        properties = new MaterialPropertyBlock();

        phosphorusObjects = GameObject.FindGameObjectsWithTag("Phosphorus");

        foreach(GameObject tagObject in phosphorusObjects)
        {
            phosphorusRenderers.Add(tagObject.GetComponent<Renderer>());
        }
    }

    private void LateUpdate()
    {
        if (phosphorusRenderers.Count <= 0 || targetLight == null)
            return;

        bool isLightAwake = lightManager.IsLightAwakeParent();

        foreach (GameObject loopPhosphorus in phosphorusObjects)
        {
            Renderer renderer = loopPhosphorus.GetComponent<Renderer>();

            renderer.GetPropertyBlock(properties);

            if(isLightAwake)
            {
                properties.SetVector(
                "_LightPosition",
                targetLight.transform.position
                 );
            }
            else
            {
                properties.SetVector(
                "_LightPosition",
                new Vector3(1000, 10000, 1000)
                 );
            }
            

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

            if (loopPhosphorus.TryGetComponent<ColorChanger>(out ColorChanger changer))
            {
                properties.SetColor("_BaseColor", changer.GetColor());
            }

            renderer.SetPropertyBlock(properties);
        }
    }
}

/*
 * targetRenderer.GetPropertyBlock(properties);

        properties.SetVector(
            "_LightPosition",
            targetLight.transform.position
        );

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
    }*/
