using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilding : MonoBehaviour
{
    public Vector2Int Size = Vector2Int.one;

    [SerializeField] private Renderer renderer;
    [SerializeField] private Tower tower;
    [SerializeField] private GameObject towerRadiusDamage;

    [SerializeField] private List<GameObject> enemiesAroundTower;


    private void Awake()
    {
        towerRadiusDamage.transform.localScale = new Vector3(tower.radiusDamage * 2, tower.radiusDamage * 2,
            towerRadiusDamage.transform.localScale.z);
    }

    public IEnumerator StartAttack()
    {
        DetectEnemiesAroundTower(EnemiesController.Instance.enemies);
        
        if (enemiesAroundTower.Count != 0)
        {
            EnemyController tmpEnemy = enemiesAroundTower[0].GetComponent<EnemyController>();
            if (!tmpEnemy.EnemyKilled(tower.damage, this))
                tmpEnemy.ReceiveDamage(tower.damage);
            else
                StartCoroutine(StartAttack());
        }
        
        yield return new WaitForSeconds(tower.speed);
        
        StartCoroutine(StartAttack());
    }


    public void DeleteEnemyFromList(EnemyController _enemy)
    {
        for (int i = 0; i < enemiesAroundTower.Count; i++)
        {
            if (_enemy.gameObject == enemiesAroundTower[i])
            {
                enemiesAroundTower.Remove(enemiesAroundTower[i]);
            }
        }
        
    }
    public void DetectEnemiesAroundTower(List<GameObject> enemies)
    {
        enemiesAroundTower.Clear();
        
        for (int i = 0; i < enemies.Count; i++)
        {
            if (Mathf.Abs(Vector2.Distance(transform.position,enemies[i].transform.position)) <= tower.radiusDamage)
            {
                enemiesAroundTower.Add(enemies[i]);
            }
        }

    }

    public void ShowRadiusDamage()
    {
        towerRadiusDamage.SetActive(true);
    }

    public void TurnOffShowRadiusDamage()
    {
        towerRadiusDamage.SetActive(false);
    }

    public void SetTransparent(bool available)
    {
        ShowRadiusDamage();
        if (available)
        {
            renderer.material.color = new Color(0f, 1f, 0f, 0.7f);
        }
        else
        {
            renderer.material.color = new Color(1f, 0f, 0f, 0.7f);
        }
    }

    public void SetNormal()
    {
        TurnOffShowRadiusDamage();
        renderer.material.color = Color.white;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 0.29f);
                Gizmos.DrawCube(transform.position + new Vector3(i, j, 0), new Vector3(1, 1, 0));

                UnityEditor.Handles.color = Color.green;
                UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, tower.radiusDamage);
            }
        }
    }

}
