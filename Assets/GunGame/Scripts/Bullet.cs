using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 _direction = Vector3.forward;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _force = 100f;
    [SerializeField] private float _lifeTimeSec = 3f;

    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = transform.position;
        Destroy(gameObject, _lifeTimeSec);
    }

    private void FixedUpdate()
    {
        Vector3 transformDirection = transform.TransformDirection(_direction);
        transform.position += transformDirection * _speed * Time.fixedDeltaTime;

        float rayLength = Vector3.Distance(_lastPosition, transform.position);
        RaycastHit hit;
        // Check if the bullet has passed through the obstacle between the frames
        if (Physics.Raycast(_lastPosition, transformDirection, out hit, rayLength))
        {
            if (hit.transform.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(transformDirection * _speed * _force);
            }
            Destroy(gameObject);
        }

        _lastPosition = transform.position;
    }
}
