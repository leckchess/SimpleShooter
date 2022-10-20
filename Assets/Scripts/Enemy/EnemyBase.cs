using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyBase : MonoBehaviour
{
    protected enum State { isWandering, isChasing, isDead, inCombat};

    [SerializeField] protected float _speed;
    [SerializeField] private float _wanderTime;
    [SerializeField] private float _health;

    [SerializeField] private Image _hpImage;

    [SerializeField] protected State currentState = State.isWandering;


    private float _currHealth;

    private void Start()
    {
        _currHealth = _health;
        UpdateHPBar();
    }

    protected void Update()
    {
        if (currentState != State.isWandering)
            return;

        if(_wanderTime > 0)
        {
            transform.Translate(Vector3.forward * _speed);
            _wanderTime -= Time.deltaTime;
        }
        else 
        {
            _wanderTime = Random.Range(5.0f, 15.0f);
            Wander();
        }
    }

    private void Wander()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            _currHealth -= other.GetComponent<Bullet>().Damage;
            UpdateHPBar();
            if (_currHealth <= 0)
                Die();
        }
    }

    private void Die()
    {
        currentState = State.isDead;
        Destroy(gameObject, 0.1f);
    }

    private void UpdateHPBar()
    {
        if (!_hpImage)
            return;

        _hpImage.fillAmount = _currHealth / _health;
    }
}
