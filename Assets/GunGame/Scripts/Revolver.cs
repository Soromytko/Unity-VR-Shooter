using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Revolver : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private AimCanvas _aimCanvas;
    [SerializeField] private LayerMask _ignoreRaycastMask;

    private HapticInteractable _hapticInteractable;

    public void Shoot()
    {
        _bulletSpawner.SpawnBullet();
    }

    private void Start()
    {
        _hapticInteractable = GetComponent<HapticInteractable>();
        
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(call =>
        {
            Shoot();
            if (call.interactorObject is XRBaseControllerInteractor controllerInteractor)
            {
                TriggerHatpic(controllerInteractor.xrController);
            }
        });

        if (_aimCanvas != null)
        {
            _aimCanvas.gameObject.SetActive(true);
        }
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
            SetScreenAimPosition(hit.point - rayDirection * 0.1f);
        }
        else
        {
            _aimCanvas.transform.position = rayOriginPosition + rayDirection * rayLength;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_bulletSpawner.transform.position, _bulletSpawner.transform.position + _bulletSpawner.transform.forward * 1000f);
    }

    private void SetScreenAimPosition(Vector3 globalAimPosition)
    {
        if (_aimCanvas != null)
        {
            _aimCanvas.transform.position = globalAimPosition;
        }
    }

    private void TriggerHatpic(XRBaseController controller)
    {
        if (_hapticInteractable != null && controller != null)
        {
            _hapticInteractable.TriggerHatpic(controller);
        }
    }

   

}
