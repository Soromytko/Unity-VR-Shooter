using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Revolver : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private RectTransform _aim;
    [SerializeField] private LayerMask _ignoreRaycastMask;

    public void Shoot()
    {
        _bulletSpawner.SpawnBullet();
    }

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(call =>
        {
            Shoot();
        });
    }

    private void Update()
    {
        Vector3 rayOriginPosition = _bulletSpawner.transform.position;
        Vector3 rayDirection = _bulletSpawner.transform.forward;
        float rayLength = 1000f;
        Ray ray = new Ray(rayOriginPosition, rayDirection);
        if (Physics.Raycast(ray, out RaycastHit hit, rayLength, _ignoreRaycastMask))
        //if (Physics.Raycast(rayOriginPosition, rayDirection, out hit, rayLength))
        {
            SetScreenAimPosition(hit.point);
        }
        else
        {
            SetScreenAimPosition(rayOriginPosition + rayDirection * rayLength);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_bulletSpawner.transform.position, _bulletSpawner.transform.position + _bulletSpawner.transform.forward * 1000f);
    }

    private void SetScreenAimPosition(Vector3 globalAimPosition)
    {
        if (_aim != null)
        {
            _aim.position = Camera.main.WorldToScreenPoint(globalAimPosition);
        }

    }


}
