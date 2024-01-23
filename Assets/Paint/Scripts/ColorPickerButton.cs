using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ColorPickerButton : MonoBehaviour
{
    public Color Color => _color;
    
    [SerializeField] private Color _color = Color.white;

    private void Update()
    {
        if (TryGetComponent<Button>(out Button button))
        {
            ColorBlock colors = button.colors;
            colors.normalColor = _color;
            colors.highlightedColor = _color;
            colors.pressedColor = _color * 0.7f;
            colors.selectedColor = _color * 0.7f;
            button.colors = colors;
        }

    }
}
