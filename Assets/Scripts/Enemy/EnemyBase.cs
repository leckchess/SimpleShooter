using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyBase : MonoBehaviour
{
    protected enum State { isWandering, isChasing, isDead, inCombat};

    [SerializeField] protected float _speed;
    [SerializeField] private float _wanderTime;

    [SerializeField] protected State currentState = State.isWandering;

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
}
