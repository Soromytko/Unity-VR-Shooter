using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public Color Color 
    {
        get => _color;
        set => _color = value;
    }
    public float Radius
    {
        get => _radius;
        set => _radius = value;
    }
    public float Stiffness
    {
        get => _stiffness;
        set => _stiffness = value;
    }

    [Range(0, 1)]
    [SerializeField] private float _radius = 0.05f;
    [Range(0, 1)]
    [SerializeField] private float _stiffness = 0.9f;
    [SerializeField] private Color _color = Color.red;
    
}
