using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;

public class Board : MonoBehaviour
{
    public Material Material
    {
        get => _meshRenderer.material;
        set => _meshRenderer.material = value;
    }
    public Material RenderTextureMaterial
    {
        get => _renderTextureMaterial;
        set => _renderTextureMaterial = value;
    }
    public CustomRenderTexture RenderTexture
    {
        get => _renderTexture;
        set => _renderTexture = value;
    }

    [SerializeField] private Brush _brush;
    [SerializeField] private Material _renderTextureMaterial;
    [SerializeField] private CustomRenderTexture _renderTexture;
    private MeshRenderer _meshRenderer;

    private static readonly int _brushPositionId = Shader.PropertyToID("_BrushPosition");
    private static readonly int _brushRadiusId = Shader.PropertyToID("_BrushRadius");
    private static readonly int _brushStiffnessdId = Shader.PropertyToID("_BrushStiffness");
    private static readonly int _brushColorId = Shader.PropertyToID("_BrushColor");

    public void Paint(Vector3 uv)
    {
        _renderTextureMaterial.SetFloat(_brushRadiusId, _brush.Radius);
        _renderTextureMaterial.SetFloat(_brushStiffnessdId, _brush.Stiffness);
        _renderTextureMaterial.SetColor(_brushColorId, _brush.Color);

        _renderTextureMaterial.SetVector(_brushPositionId, uv);
    }

    public void Clear()
    {        _renderTextureMaterial.SetVector(_brushPositionId, Vector3.one * -1f);
        _renderTexture.Initialize();
    }

    public void SaveAsPng()
    {
        RenderTexture renderTexture = _renderTexture.GetDoubleBufferRenderTexture();
        Texture2D texture2D = renderTexture.ToTexture2D();
        byte[] bytes = texture2D.EncodeToPNG();
        string path = "Assets/Paint/Images/" + name + ".png";
        // path = "Assets/screenshot.png";
        System.IO.File.WriteAllBytes(path, bytes);
        AssetDatabase.ImportAsset(path);
    }

}
