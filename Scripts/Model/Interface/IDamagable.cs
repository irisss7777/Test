using UnityEngine;

public interface IDamagable
{
    public void ApplyDamage(int damage);

    public Vector3 GetPosition();
}
