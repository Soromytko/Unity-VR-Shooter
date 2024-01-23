using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public Color BrushColor 
    {
        get => _brushColor;
        set => _brushColor = value;
    }

    [Range(0, 1)]
    [SerializeField] private float _brushRadius = 0.05f;
    [Range(0, 1)]
    [SerializeField] private float _brushStiffness = 0.9f;
    [SerializeField] private Color _brushColor = Color.red;

    [SerializeField] private Board _board;
    [SerializeField] private CustomRenderTexture _renderTexture;

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
            Material material = _board.RenderTextureMaterial;
            material.SetFloat(_brushRadiusId, _brushRadius);
            material.SetFloat(_brushStiffnessdId, _brushStiffness);
            material.SetColor(_brushColorId, _brushColor);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent<Board>(out Board board))
                {
                    Vector2 textCoord = hit.textureCoord;
                    material.SetVector(_brushPositionId, textCoord);
                }
            }
        }
    }
}
