using UnityEngine;

public class EnemySmart : EnemyBase
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _detectPlayerRange;
    [SerializeField] private LayerMask _playerLayerMask;
    
    private Shooter _shooter;
    private Transform _player;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
    }
    protected void Update()
    {
        base.Update();

        GetPlayer();

        if (_player)
        {
            currentState = State.isChasing;

            Collider[] HitResult = Physics.OverlapSphere(transform.position, _attackRange, _playerLayerMask);
            if (HitResult.Length > 0)
            {
                currentState = State.inCombat;
            }

            UpdateMovement();
        }
        else
        {
            currentState = State.isWandering;
        }

    }

    private void GetPlayer()
    {
        Collider[] HitResult = Physics.OverlapSphere(transform.position, _detectPlayerRange, _playerLayerMask);

        if (HitResult.Length > 0)
            _player = HitResult[0].transform;

        else
            _player = null;
    }

    private void UpdateMovement()
    {
        if (!_player)
            return;

        Vector3 playerDirection = _player.position - transform.position;
        transform.LookAt(playerDirection.normalized);

        if (currentState == State.isChasing)
            transform.position = Vector3.Lerp(transform.position, playerDirection, Time.deltaTime * _speed);

        else if (currentState == State.inCombat)
            _shooter.Shoot(playerDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _detectPlayerRange);
    }
}
