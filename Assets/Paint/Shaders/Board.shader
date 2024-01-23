Shader "Custom/Board"
{
    Properties
    {
        // Входные данные, которые задаются из скрипта Brush

        // Позиция, в которой нужно рисовать
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
            
            // Фрагментный шейдер
            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                // Вычисляем жесткость кисти
                float stiffness = _BrushRadius * _BrushStiffness;
                // Вычисляем дистанцию между позицией кисти и текущим фрагментом
                float dist = distance(IN.localTexcoord.xy, _BrushPosition);
                // smoothstep - интерполяция для плавных краев кисточки 
                float smooth = smoothstep(stiffness, _BrushRadius, dist);

                // Вычисляем цвет текстуры (текущий цвет пикселя)
                float4 textureColor = tex2D(_SelfTexture2D, IN.localTexcoord.xy) * smooth;
                // Вычисляем цвет Кисти   
                float4 brushColor = _BrushColor * (1 - smooth);
                
                // Складываем цвет текстуры и цвет кисти
                float4 color = textureColor + brushColor;

                return color;
            }
            ENDCG
        }
    }
}