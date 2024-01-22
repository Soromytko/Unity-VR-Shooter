using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCanvas : MonoBehaviour
{
    public float Size
    {
        get => _size;
        set => _size = value;
    }

    [SerializeField] private float _size = 1f;

    private void LateUpdate()
    {
        float distanceToCamera = Vector3.Distance(Camera.main.transform.position, transform.position);
        transform.localScale = Vector3.one * (_size * distanceToCamera * 0.01f);

        transform.LookAt(Camera.main.transform);
    }

}
