using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    private Vector3 _targetPosition;
    private IDamagable _target;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _targetLayer;
    private const float MAXDISBETWENNBULLETNTARGET = 1f;

    public void Init(IDamagable target, Vector3 targetPosition)
    {
        _target = target;
        _targetPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            MoveToTarget();
            TryCatchTarget();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed);
        if(transform.position == _targetPosition)
        {
            Destroy(this.gameObject);
        }
    }

    private void TryCatchTarget()
    {
        Collider2D[] targetColliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _targetLayer);
        foreach (Collider2D currentTarget in targetColliders)
        {
            float distance = Vector3.Magnitude(transform.position - currentTarget.gameObject.transform.position);
            if (distance < MAXDISBETWENNBULLETNTARGET)
            {
                try
                {
                    currentTarget.gameObject.GetComponent<EnemyBaseModel>().ApplyDamage(_damage);
                    Destroy(this.gameObject);
                }
                catch (MissingComponentException)
                {
                    Debug.Log("Object on target layer miss EnemyBaseModel() class");
                }
            }
        }
    }
}
