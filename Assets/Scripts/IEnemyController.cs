using System.Collections;
using UnityEngine;

public interface IEnemyController
{
    public void ReceiveDamage(int _damage);
    public IEnumerator Move(Vector3 pos);
}
