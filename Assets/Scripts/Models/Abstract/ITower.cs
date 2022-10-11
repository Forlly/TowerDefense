using System.Collections.Generic;
using System.Numerics;

namespace Models.Abstract
{
    public abstract class ITower : IAttackble
    {
        public int ID;
        public TowerType TowerType;
        public int Level;

        public List<ISkill> Skills = new List<ISkill>();
        
        public Vector2 Position;
        
        public virtual void Init()
        {
            
        }
        
        public virtual bool TryAttack(List<IUnit> units)
        {
            if (Skills.Count == 0)
                return false;
            
            List<IUnit> targets;
            bool attacked = false;
            
            foreach (ISkill skill in Skills)
            { 
                targets = skill.GetTargets(units);

                if (skill.TryAttack(targets) && !attacked)
                    attacked = true;
            }

            return attacked;
        }

        public virtual void Destroy()
        {
            
        }
    }
}