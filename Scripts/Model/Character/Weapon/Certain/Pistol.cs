using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private void Awake()
    {
        _maxAmmo = 40;
        _currentAmmo = _maxAmmo;
        _shootAmmoCount = 1;
    }

    public override void Shoot(Vector3 position, IDamagable target, GameObject prefab)
    {
        Instantiate(prefab, position, Quaternion.identity).GetComponent<Bullet>().Init(target, target.GetPosition());
    }
}
