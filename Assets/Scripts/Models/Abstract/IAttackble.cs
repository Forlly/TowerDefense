using System.Collections.Generic;

namespace Models.Abstract
{
    public interface IAttackble
    {
        public bool TryAttack(List<IUnit> units);
    }
}