using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    public void SpawnBullet()
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}
