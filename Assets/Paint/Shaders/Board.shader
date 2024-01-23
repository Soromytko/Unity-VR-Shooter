Shader "Custom/Board"
{
    Properties
    {
        _BrushPosition ("Brush Position", Vector) = (-1, -1, 0, 0)
        _BrushRadius ("Brush Radius", Range(0, 1)) = 0.2
        _BrushStiffness ("Brush Stiffness", Range(0, 1)) = 1
        _BrushColor ("Brush Color", Color) = (1, 0, 0, 1)
    }

    SubShader
    {
        Lighting Off
        Blend One Zero
        
        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0
            
            float4 _BrushPosition;
            float _BrushRadius;
            float _BrushStiffness;
            float4 _BrushColor;
            
            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                float stiffness = _BrushRadius * _BrushStiffness;
                float dist = distance(IN.localTexcoord.xy, _BrushPosition);
                float smooth = smoothstep(stiffness, _BrushRadius, dist);

                float4 textureColor = tex2D(_SelfTexture2D, IN.localTexcoord.xy) * smooth;   
                float4 brushColor = _BrushColor * (1 - smooth);
                
                float4 color = textureColor + brushColor;

                return color;
            }
            ENDCG
        }
    }
}