using System.Collections;
using UnityEngine;

public class SMG : Shooter
{
    [SerializeField] private float _timeBetweenBullets = 0.2f;
    private bool _canShoot = true;

    public override void Shoot(Vector3 direction)
    {
        _canShoot = true;
        StartCoroutine(ContFire(direction));
    }

    private IEnumerator ContFire(Vector3 direction)
    {
        if (!_canShoot)
            yield break;

        FireBullet(direction);
        yield return new WaitForSeconds(_timeBetweenBullets);

        StartCoroutine(ContFire(direction));
    }

    public override void StopShooting()
    {
        _canShoot = false;
    }
}
