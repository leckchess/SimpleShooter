using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private FixedJoystick _joySTick;

    private Rigidbody _rigidbody;

    private void Start()
    {
        if (!_rigidbody)
            _rigidbody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (!_rigidbody)
            return;

        _rigidbody.velocity = new Vector3(_joySTick.Horizontal * _speed, _rigidbody.velocity.y, _joySTick.Vertical * _speed);
    }
}
