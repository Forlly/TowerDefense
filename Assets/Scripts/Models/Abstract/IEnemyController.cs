using System.Collections;
using UnityEngine;

namespace Models.Abstract
{
    public interface IEnemyController
    {
        public void ReceiveDamage(int _damage);
        public IEnumerator Move(Vector3 pos);
    }
}