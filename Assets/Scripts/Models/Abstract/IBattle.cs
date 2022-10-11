using System.Collections.Generic;

namespace Models.Abstract
{
    public abstract class IBattle
    {
        public List<ITower> Towers = new List<ITower>();
        public List<IUnit> Units = new List<IUnit>();

        public virtual void Init()
        {
            
        }

        public virtual void Start()
        {
            
        }

        public virtual void Tick(int mSec)
        {
            
        }

        public virtual void End()
        {
            
        }
    }
}