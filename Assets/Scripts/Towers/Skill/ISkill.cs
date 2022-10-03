using UnityEngine;

public abstract class ISkill
{
    public int damage;
    public bool AOEDamage;
    public int countOfTarget;

    public virtual void SetDamage()
    {
        damage = 10;
    }
    public virtual void Attack(EnemyController _enemy)
    {
        _enemy.ReceiveDamage(damage);
    }
}
