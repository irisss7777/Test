using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShootGun : Weapon
{
    private void Awake()
    {
        _maxAmmo = 40;
        _currentAmmo = _maxAmmo;
        _shootAmmoCount = 5;
    }

    public override void Shoot(Vector3 position, IDamagable target, GameObject prefab)
    {
        List<Vector3> allTargetsPosition = new List<Vector3>(_shootAmmoCount);
        NewBulletPositionForShootGun(ref allTargetsPosition, target);
        for (int i = 0; i < _shootAmmoCount; i++)
        {
            Instantiate(prefab, position, Quaternion.identity).GetComponent<Bullet>().Init(target, allTargetsPosition[i]);
        }
    }

    public void NewBulletPositionForShootGun(ref List<Vector3> allTargetsPosition, IDamagable target)
    {
        float offset = 0.5f;
        Vector3 startTargetPosition = target.GetPosition();
        allTargetsPosition.Add(startTargetPosition);
        if(transform.position.x >= target.GetPosition().x && transform.position.y >= target.GetPosition().y)
        {
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset, startTargetPosition.y - offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset * 2, startTargetPosition.y - offset * 2, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset, startTargetPosition.y + offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset * 2, startTargetPosition.y + offset * 2, startTargetPosition.z));
        }
        if (transform.position.x < target.GetPosition().x && transform.position.y >= target.GetPosition().y)
        {
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset, startTargetPosition.y + offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset * 2, startTargetPosition.y + offset * 2, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset, startTargetPosition.y - offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset * 2, startTargetPosition.y - offset * 2, startTargetPosition.z));
        }
        if (transform.position.x >= target.GetPosition().x && transform.position.y < target.GetPosition().y)
        {
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset, startTargetPosition.y + offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset * 2, startTargetPosition.y + offset * 2, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset, startTargetPosition.y - offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset * 2, startTargetPosition.y - offset * 2, startTargetPosition.z));
        }
        if (transform.position.x < target.GetPosition().x && transform.position.y < target.GetPosition().y)
        {
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset, startTargetPosition.y - offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x + offset * 2, startTargetPosition.y - offset * 2, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset, startTargetPosition.y + offset, startTargetPosition.z));
            allTargetsPosition.Add(new Vector3(startTargetPosition.x - offset * 2, startTargetPosition.y + offset * 2, startTargetPosition.z));
        }
    }
}
