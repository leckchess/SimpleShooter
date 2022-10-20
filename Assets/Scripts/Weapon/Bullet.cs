using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime = 2;
    [SerializeField] private float _damage = 1;

    public UnityAction<Transform> onTargetReached;
    public float Damage { get { return _damage; } }

    public void Fire(Vector3 direction)
    {
        gameObject.SetActive(true);
        transform.parent = null;
        GetComponent<Rigidbody>().velocity = (direction * _speed);

        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && CompareTag("PlayerBullet") || other.CompareTag("Player") && CompareTag("EnemyBullet"))
            onTargetReached?.Invoke(transform);
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_lifeTime);
        onTargetReached?.Invoke(transform);
    }
}
