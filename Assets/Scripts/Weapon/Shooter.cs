using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _bulletsPoolSize = 50;

    [SerializeField] private Texture2D _representationImage;

    public Texture2D RepresentationImage { get{ return _representationImage; } }

    private Queue<GameObject> _bulletsPool;

    private void Start()
    {
        _bulletsPool = new Queue<GameObject>();

        if (_bulletsPool.Count == 0)
            GenerateBullets();
    }

    private void GenerateBullets()
    {
        if (!_bulletPrefab)
            return;

        for(int i=0;i< _bulletsPoolSize; i++)
        {
            GameObject bullet = InstantiateBullet();
            _bulletsPool.Enqueue(bullet);
        }
    }

    public virtual void Shoot(Vector3 direction) { }

    protected void FireBullet(Vector3 direction)
    {
        GameObject bullet = null;

        if (_bulletsPool.Count == 0)
        {
            bullet = InstantiateBullet();
        }
        else
            bullet = _bulletsPool.Dequeue();

        if (bullet)
            bullet.GetComponent<Bullet>().Fire(direction);
    }

    public virtual void StopShooting() { }

    private void OnBulletCollision(Transform bulletTransform)
    {
        bulletTransform.gameObject.SetActive(false);
        bulletTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bulletTransform.SetParent(transform);
        bulletTransform.localPosition = Vector3.zero;
    }

    private GameObject InstantiateBullet()
    {
        if (!_bulletPrefab)
            return null;

        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = Vector3.zero;
        bullet.SetActive(false);
        bullet.GetComponent<Bullet>().onTargetReached += OnBulletCollision;

        return bullet;
    }
}
