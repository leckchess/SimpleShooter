using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Shooter
{
    public override void Shoot(Vector3 direction)
    {
        FireBullet(direction);
    }
}
