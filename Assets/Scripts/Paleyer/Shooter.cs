using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _bulletsPoolSize;

    private Queue<GameObject> _bulletsPool;

    private void Start()
    {
        _bulletsPool = new Queue<GameObject>();

        if (_bulletsPool.Count == 0)
            GenerateBullets();
    }

    private void GenerateBullets()
    {
        for(int i=0;i< _bulletsPoolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.SetParent(transform);
            bullet.transform.localPosition = Vector3.zero;
            bullet.SetActive(false);
            bullet.GetComponent<Bullet>().onTargetReached += OnBulletCollision;

            _bulletsPool.Enqueue(bullet);
        }
    }

    public void Shoot()
    {
        GameObject bullet = _bulletsPool.Dequeue();
        bullet.GetComponent<Bullet>().Fire();
    }

    private void OnBulletCollision(Transform bulletTransform)
    {
        bulletTransform.SetParent(transform);
        bulletTransform.localPosition = Vector3.zero;
    }
}
