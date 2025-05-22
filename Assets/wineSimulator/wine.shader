Shader "Custom/wine"
{
    Properties
    {
        _Color ("Color", Color) = (0.5, 0.0, 0.1, 0.8)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.95
        _Metallic ("Metallic", Range(0,1)) = 0.1
        _Transparency ("Transparency", Range(0,1)) = 0.8
        _Refraction ("Refraction", Range(0,1)) = 0.1
        
        // Wobble Effect Properties
        _WobbleAmount ("Wobble Intensity", Range(0, 0.5)) = 0.1
        _WobbleSpeed ("Wobble Speed", Range(0, 5)) = 1.5
        _WobbleFrequency ("Wobble Frequency", Range(0, 10)) = 3.0
    }
    SubShader
    {
        Tags { 
            "RenderType"="Transparent" 
            "Queue"="Transparent"
        }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:fade vertex:vert
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        half _Transparency;
        half _Refraction;
        fixed4 _Color;

        // Wobble Parameters
        float _WobbleAmount;
        float _WobbleSpeed;
        float _WobbleFrequency;

        // Vertex displacement function for wobble effect
        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            
            // Animate wobble using sine waves
            float time = _Time.y * _WobbleSpeed;
            float wobbleX = sin(time + v.vertex.x * _WobbleFrequency) * _WobbleAmount;
            float wobbleZ = cos(time + v.vertex.z * _WobbleFrequency) * _WobbleAmount;
            
            // Apply displacement (mostly affecting the top of the liquid)
            float wobbleFactor = saturate(v.vertex.y * 2.0); // Stronger wobble at the top
            v.vertex.x += wobbleX * wobbleFactor;
            v.vertex.z += wobbleZ * wobbleFactor;
            
            // Modify normals for better light interaction
            v.normal = normalize(float3(
                v.normal.x + wobbleX * 0.5,
                v.normal.y,
                v.normal.z + wobbleZ * 0.5
            ));
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            
            // Create a wine-like color with depth variation
            float depthFactor = 1.0 - saturate(dot(normalize(IN.viewDir), float3(0,1,0)));
            float3 wineColor = lerp(c.rgb * 0.7, c.rgb, depthFactor);
            
            o.Albedo = wineColor;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = _Color.a * _Transparency;
            
            // Add some refraction effect
            o.Normal = float3(0, 0, _Refraction);
        }
        ENDCG
    }
    FallBack "Transparent"
}