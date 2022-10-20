
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigitbody;

    public UnityAction<Transform> onTargetReached;

    public void Fire()
    {
        transform.parent = null;
        _rigitbody.AddForce(transform.forward * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        onTargetReached?.Invoke(transform);
    }
}
