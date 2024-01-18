using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Revolver : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Transform _aimPrefab;

    private Transform _aim;

    public void Shoot()
    {
        _bulletSpawner.SpawnBullet();
    }

    private void Start()
    {
        _aim = Instantiate(_aimPrefab);

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(call =>
        {
            print("AAAAAAAAAAAAA");
            Shoot();
        });
    }

private void Update()
    {
        _aim.gameObject.SetActive(false);

        Vector3 rayOriginPosition = _bulletSpawner.transform.position;
        Vector3 rayDirection = _bulletSpawner.transform.forward;
        float rayLength = Mathf.Infinity;
        RaycastHit hit;
        if (Physics.Raycast(rayOriginPosition, rayDirection, out hit, rayLength))
        {
            _aim.gameObject.SetActive(true);
            _aim.transform.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
       
    }

    
}
