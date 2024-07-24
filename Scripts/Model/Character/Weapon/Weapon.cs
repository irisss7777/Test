using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected int _maxAmmo;
    protected int _shootAmmoCount;
    protected int _currentAmmo;
    protected int _bulletDamage;

    public virtual void TryShoot(Vector3 position, IDamagable target, GameObject prefab)
    {
        if(_currentAmmo >= _shootAmmoCount)
        {
            Shoot(position, target, prefab);
            _currentAmmo -= _shootAmmoCount;
        }
    }

    public abstract void Shoot(Vector3 position, IDamagable target, GameObject prefab);

    public virtual void AddAmmo(int ammoValue)
    {
        if (ammoValue > 0)
        {
            if (_currentAmmo + ammoValue <= _maxAmmo)
            {
                _currentAmmo += ammoValue;
            }
            else
            {
                _currentAmmo = _maxAmmo;
            }
        }
    }

    public virtual void DeleteThisComponent()
    {
        Destroy(this);
    }
}
