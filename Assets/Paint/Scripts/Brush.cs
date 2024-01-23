using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] private CustomRenderTexture _renderTexture;
    [SerializeField] private Material _textureMaterial;

    [Range(0, 1)]
    [SerializeField] private float _brushRadius = 0.05f;
    [Range(0, 1)]
    [SerializeField] private float _brushStiffness = 0.9f;
    [SerializeField] private Color _brushColor = Color.red;

    private static readonly int _brushPositionId = Shader.PropertyToID("_BrushPosition");
    private static readonly int _brushRadiusId = Shader.PropertyToID("_BrushRadius");
    private static readonly int _brushStiffnessdId = Shader.PropertyToID("_BrushStiffness");
    private static readonly int _brushColorId = Shader.PropertyToID("_BrushColor");

    private void Start()
    {
        // Clear texture
        _renderTexture.Initialize();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _textureMaterial.SetFloat(_brushRadiusId, _brushRadius);
            _textureMaterial.SetFloat(_brushStiffnessdId, _brushStiffness);
            _textureMaterial.SetColor(_brushColorId, _brushColor);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2 textCoord = hit.textureCoord;
                _textureMaterial.SetVector(_brushPositionId, textCoord);
            }
        }


    }
}
