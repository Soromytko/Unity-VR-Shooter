using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAim : MonoBehaviour
{
    [SerializeField] private float _size = 1f;

    private void Update()
    {
        transform.localScale = Vector3.one * _size;
    }
}
