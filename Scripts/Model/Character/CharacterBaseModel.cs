using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseModel : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private Weapon _myCurrentWeapon;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private CharacterSerachTarget _characterSerachTarget;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ChangeWeapon(int weaponType)
    {
        if(_myCurrentWeapon != null)
        {
            _myCurrentWeapon.DeleteThisComponent();
        }
        switch(weaponType)
        {
            case 0:
                _myCurrentWeapon = gameObject.AddComponent(typeof(Pistol)) as Weapon;
            break;

            case 1:
                _myCurrentWeapon = gameObject.AddComponent(typeof(ShootGun)) as Weapon;
            break;
        }
    }

    public void TryShoot()
    {
        IDamagable target;
        _characterSerachTarget.SearchTarget(this.transform.position, out target);
        if (_myCurrentWeapon != null && target != null)
        {
            _myCurrentWeapon.TryShoot(this.transform.position, target, _bulletPrefab);
        }
    }
}
