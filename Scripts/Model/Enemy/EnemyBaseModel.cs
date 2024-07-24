using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseModel : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            if(value > 0)
            {
                _currentHealth -= value;
                if(_currentHealth <= 0)
                {
                    _currentHealth = 0;
                }
            }
        }
    }
    [SerializeField] private CharacterBaseModel _player;

    public void ApplyDamage(int damage)
    {
        CurrentHealth = damage;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
