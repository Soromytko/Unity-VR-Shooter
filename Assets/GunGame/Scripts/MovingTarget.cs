using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float Speed
    {
        set => _speed = value;
    }
    [SerializeField] private float _deviation = 3f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private AnimationCurve _curve;

    private Vector3 _basePosition;
    private float _xRotation;
    private float _currentTime;

    private bool _isFall = false;
    private float _fallenTime = 0f;

    public void TakeDamage()
    {
        _isFall = true;
    }

    private void Start()
    {
        _basePosition = transform.position;
    }

    private void Update()
    {
        float rotateTarget = _isFall ? -70 : 0f;
        float fallSpeed = Time.deltaTime * 200f;
        _xRotation = Mathf.MoveTowards(_xRotation, rotateTarget, fallSpeed);
        transform.eulerAngles = new Vector3(_xRotation, 0, 0);

        if (_isFall)
        {
            _fallenTime += Time.deltaTime;
            if (_fallenTime >= 3f)
            {
                _isFall = false;
                _fallenTime = 0f;
            }
        }
        else
        {
            float totalCurveTime = _curve.keys[_curve.keys.Length - 1].time;
            _currentTime += Time.deltaTime * _speed;
            if (_currentTime >= totalCurveTime) {
                _currentTime -= totalCurveTime;
            }
            float currentValue = _curve.Evaluate(_currentTime);
            transform.position = _basePosition + transform.right * currentValue * _deviation;
        }
    }

    private void OnDrawGizmos()
    {
        float minValue = _curve.keys.Min(x => x.value);
        float maxValue = _curve.keys.Max(x => x.value);

        Vector3 origin = transform.position;

        Vector3 firstPoint = origin + transform.right * minValue * _deviation;
        Vector3 secondPoint = origin + transform.right * maxValue * _deviation;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(firstPoint + Vector3.up, secondPoint + Vector3.up);
    }
}
