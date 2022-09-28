using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTowerBuilding : ITower
{
    
    public override IEnumerator StartAttack()
    {
        DetectEnemiesAroundTower(EnemiesController.Instance.enemies);
        
        if (enemiesAroundTower.Count != 0)
        {
            EnemyController tmpEnemy = enemiesAroundTower[0].GetComponent<EnemyController>();
            if (!tmpEnemy.EnemyKilled(tower.damage, this))
                tmpEnemy.ReceiveDamage(tower.damage);
        }
        
        yield return new WaitForSeconds(tower.speed);
        
        StartCoroutine(StartAttack());
    }


    public override void DetectEnemiesAroundTower(List<GameObject> enemies)
    {
        enemiesAroundTower.Clear();
        
        for (int i = 0; i < enemies.Count; i++)
        {
            if (Mathf.Abs(Vector2.Distance(transform.position,enemies[i].transform.position)) 
                <= tower.radiusDamage)
            {
                enemiesAroundTower.Add(enemies[i]);
            }
        }

    }


}
