using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Models.Abstract
{
    public abstract class ISkill : IAttackble
    {
        public int ID;
        public ITower Owner;
        
        public int Damage;
        public float RadiusDamage;

        public virtual List<IUnit> GetTargets(List<IUnit> units)
        {
            return units.Where(t => Math.Abs(Vector2.Distance(Owner.Position, t.Position)) <= RadiusDamage).ToList();
        }
        
        public virtual bool TryAttack(List<IUnit> targets)
        {
            if (targets.Count == 0)
                return false;
            
            foreach (IUnit unit in targets)
            {
                unit.ReceiveDamage(Damage);
            }

            return true;
        }
    }
}
