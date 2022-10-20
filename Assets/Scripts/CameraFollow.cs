using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset;

    private void Update()
    {
        if (!_target)
            return;

        transform.position = _target.position + _offset;
    }
}
