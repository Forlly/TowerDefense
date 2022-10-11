using System.Numerics;

namespace Models.Abstract
{
    public abstract class IUnit
    {
        public int ID;
        public float MoveSpeed;
        public int Health;
        public EnemyType EnemyType;

        public Vector2 Position;
        public int PositionIndex;
        
        public virtual void ReceiveDamage(int _damage)
        {
            if (Health <= 0)
                return;
           
            Health -= _damage;
            
            if (Health <= 0)
            {
                Die();
            }
        }
        
        public virtual bool Move(Vector2 pos)
        {
            
            
            return false;
        }

        public virtual void Die()
        {
            
        }
    }
}