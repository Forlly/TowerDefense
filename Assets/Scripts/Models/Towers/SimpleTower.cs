using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTower : ITower
{
    
    public override IEnumerator StartAttack()
    {
        DetectEnemiesAroundTower(EnemiesController.Instance.enemies);
        
        if (enemiesAroundTower.Count != 0)
        {
            UnitView tmpEnemy = enemiesAroundTower[0].GetComponent<UnitView>();
            if (!tmpEnemy.EnemyKilled(tower.damage, this))
                tmpEnemy.ReceiveDamage(tower.damage);
        }
        
        yield return new WaitForSeconds(tower.speed);
        
        StartCoroutine(StartAttack());
    }


}
