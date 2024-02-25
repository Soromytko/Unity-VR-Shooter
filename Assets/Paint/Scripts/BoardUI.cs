using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private Brush _brush;
    [SerializeField] private Slider _brushRadiusSlider;
    [SerializeField] private Slider _brushStiffnessSlider;
    [SerializeField] private ColorPickerButton[] _colorPickerButtons;
    [SerializeField] private BoardPickerButton[] _boardPickerButtons;

    public void SaveCurrentBoardAsPng()
    {
        _board.SaveAsPng();
    }

    public void ClearCurrentBoard()
    {
        _board.Clear();
    }

    private void Start()
    {
        _brushRadiusSlider.onValueChanged.AddListener((value) =>
        {
            _brush.Radius = _brushRadiusSlider.value;
        });

        _brushStiffnessSlider.onValueChanged.AddListener((value) =>
        {
            _brush.Stiffness = _brushStiffnessSlider.value;
        });

        foreach (ColorPickerButton colorPickerButton in _colorPickerButtons)
        {
            if (colorPickerButton.TryGetComponent<Button>(out Button button))
            {
                button.onClick.AddListener(() =>
                {
                    if (_brush != null)
                    {
                        _brush.Color = colorPickerButton.Color;
                    }
                });
            }
        }

        foreach (BoardPickerButton boardPickerButton in _boardPickerButtons)
        {
            if (boardPickerButton.TryGetComponent<Button>(out Button button))
            {
                button.onClick.AddListener(() =>
                {
                    if (_board != null)
                    {
                        _board.Material = boardPickerButton.Board.Material;
                        _board.RenderTextureMaterial = boardPickerButton.Board.RenderTextureMaterial;
                        _board.RenderTexture = boardPickerButton.Board.RenderTexture;
                    }
                });
            }
        }
    }

    private void Update()
    {
        // TODO: debug
        if (Input.GetKeyDown(KeyCode.Alpha1)) _boardPickerButtons[0].GetComponent<Button>().onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha2)) _boardPickerButtons[1].GetComponent<Button>().onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha3)) _boardPickerButtons[2].GetComponent<Button>().onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.S)) SaveCurrentBoardAsPng();
        if (Input.GetKeyDown(KeyCode.C)) ClearCurrentBoard();
        
        if (Input.GetKeyDown(KeyCode.R)) _brushRadiusSlider.value = 0.1f;
    }


}
