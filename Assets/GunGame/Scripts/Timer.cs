using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float Value {
        get => _value;
        set => _value = value;
    }
    public bool IsStimulate {
        get => _isStimulate;
        set => _isStimulate = value;
    }
    [SerializeField] private Text _text;
    [SerializeField] private float _value;
    [SerializeField] private bool _rounded = false;
    [SerializeField] private bool _isStimulate = false;
    public UnityEvent Elapsed;

    public void StartTimer()
    {
        IsStimulate = true;
    }
    
    private void Update()
    {
        if(!IsStimulate) {
            return;
        }
        
        _value -= Time.deltaTime;
        float currentValue = _rounded ? (int)_value : _value;
        if (_value < 0) {
            Elapsed?.Invoke();
            _value = 0;
        }
        _text.text = currentValue.ToString();
    }
}
