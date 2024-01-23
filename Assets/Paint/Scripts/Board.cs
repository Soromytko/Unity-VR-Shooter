using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private Material _renderTextureMaterial;
    [SerializeField] private CustomRenderTexture _renderTexture;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
}
