using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSerachTarget : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _targetLayer;

    public void SearchTarget(Vector3 characterPosition, out IDamagable target)
    {
        target = null;
        float disToTarget = Mathf.Infinity;
        Collider2D[] targetColliders = Physics2D.OverlapCircleAll(characterPosition, _attackRadius, _targetLayer);
        foreach(Collider2D currentTarget in targetColliders)
        {
            float distance = Vector3.Magnitude(characterPosition - currentTarget.gameObject.transform.position);
            if(distance < disToTarget)
            {
                try
                {
                    disToTarget = distance;
                    target = currentTarget.gameObject.GetComponent<EnemyBaseModel>();
                }
                catch(MissingComponentException)
                {
                    Debug.Log("Object on target layer miss EnemyBaseModel() class");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
