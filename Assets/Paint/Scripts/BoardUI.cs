using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private Brush _brush;
    [SerializeField] private ColorPickerButton[] _colorPickerButtons;
    [SerializeField] private BoardPickerButton[] _boardPickerButtons;

    private void Start()
    {
        _colorPickerButtons = GetComponentsInChildren<ColorPickerButton>();
        _boardPickerButtons = GetComponentsInChildren<BoardPickerButton>();

        foreach (ColorPickerButton colorPickerButton in GetComponentsInChildren<ColorPickerButton>())
        {
            if (colorPickerButton.TryGetComponent<Button>(out Button button))
            {
                button.onClick.AddListener(() =>
                {
                    if (_brush != null)
                    {
                        _brush.BrushColor = colorPickerButton.Color;
                    }
                });
            }
        }

        foreach (BoardPickerButton boardPickerButton in GetComponentsInChildren<BoardPickerButton>())
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
        if (Input.GetKeyDown(KeyCode.Alpha1)) _boardPickerButtons[0].GetComponent<Button>().onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha2)) _boardPickerButtons[1].GetComponent<Button>().onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha3)) _boardPickerButtons[2].GetComponent<Button>().onClick.Invoke();
    }


}
