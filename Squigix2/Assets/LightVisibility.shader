
Shader "Custom/LightVisibility"
{
    Properties
    {
        _BaseMap ("Texture", 2D) = "white" {}
        _BaseColor ("Color", Color) = (1,1,1,1)

        _LightPosition ("Light Position", Vector) = (0,0,0,0)
        _LightDirection ("Light Direction", Vector) = (0,0,1,0)

        _LightRange ("Light Range", Float) = 10
        _InnerAngle ("Inner Angle Cosine", Float) = 0.9
        _OuterAngle ("Outer Angle Cosine", Float) = 0.8

        _VisibilityStrength ("Visibility Strength", Range(0,1)) = 1
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Back

            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                float4 _BaseColor;
                float4 _LightPosition;
                float4 _LightDirection;
                float _LightRange;
                float _InnerAngle;
                float _OuterAngle;
                float _VisibilityStrength;
            CBUFFER_END

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float2 uv : TEXCOORD2;
            };

            Varyings vert(Attributes input)
            {
                Varyings output;

                VertexPositionInputs pos =
                    GetVertexPositionInputs(input.positionOS.xyz);

                output.positionHCS = pos.positionCS;
                output.positionWS = pos.positionWS;
                output.normalWS =
                    TransformObjectToWorldNormal(input.normalOS);

                output.uv = TRANSFORM_TEX(input.uv, _BaseMap);

                return output;
            }

            /*half4 frag(Varyings input) : SV_Target
            {
                float3 normal = normalize(input.normalWS);

                // Direction from surface towards light
                float3 toLight =
                    _LightPosition.xyz - input.positionWS;

                float distanceToLight = length(toLight);
                float3 lightDir = toLight / max(distanceToLight, 0.0001);

                // Surface facing the light
                float diffuse = saturate(dot(normal, lightDir));

                // Distance attenuation
                float rangeAttenuation =
                    saturate(1.0 - distanceToLight / _LightRange);

                rangeAttenuation *= rangeAttenuation;

                // Spotlight cone attenuation
                float3 fromLight =
                    normalize(input.positionWS - _LightPosition.xyz);

                float coneDot =
                    dot(normalize(_LightDirection.xyz), fromLight);

                float spotAttenuation = smoothstep(
                    _OuterAngle,
                    _InnerAngle,
                    coneDot
                );

                // Final visibility
                float visibility =
                    (diffuse *
                    rangeAttenuation *
                    spotAttenuation *
                    _VisibilityStrength);

                half4 color = SAMPLE_TEXTURE2D(
                    _BaseMap,
                    sampler_BaseMap,
                    input.uv
                ) * _BaseColor;

                color.a *= visibility;

                return color;
            }*/
            
half4 frag(Varyings input) : SV_Target
{
    // Calculate distance from flashlight
    float distanceToLight = distance(
        _LightPosition.xyz,
        input.positionWS
    );

    // Calculate distance-based illumination
    float distanceVisibility = 1.0 - smoothstep(
        _LightRange * 0.8,
        _LightRange,
        distanceToLight
    );

    // Calculate spotlight direction
    float3 fromLight = normalize(
        input.positionWS - _LightPosition.xyz
    );

    float coneDot = dot(
        normalize(_LightDirection.xyz),
        fromLight
    );

    // Calculate spotlight coverage
    float spotVisibility = smoothstep(
        _OuterAngle,
        _InnerAngle,
        coneDot
    );

    // Calculate illumination
    float illumination =
        distanceVisibility * spotVisibility;

    // Invert illumination
    float visibility = 1.0 - illumination;

    // Apply transparency
    half4 color = SAMPLE_TEXTURE2D(
        _BaseMap,
        sampler_BaseMap,
        input.uv
    ) * _BaseColor;

    color.a *= visibility * _VisibilityStrength;

    return color;
}


            ENDHLSL
        }
    }
}
