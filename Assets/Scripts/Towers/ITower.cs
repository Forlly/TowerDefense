using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITower : MonoBehaviour
{
    [SerializeField] private GameObject towerRadiusDamage;
    [SerializeField] private Renderer renderer;
    [SerializeField] private ISkill skill;
    
    public Tower tower;
    public List<GameObject> enemiesAroundTower;
    
    public virtual void ShowRadiusDamage()
    {
        towerRadiusDamage.transform.localScale = new Vector3(tower.radiusDamage * 2, tower.radiusDamage * 2,
            towerRadiusDamage.transform.localScale.z);
        towerRadiusDamage.SetActive(true);
    }
    
    public virtual void TurnOffShowRadiusDamage()
    {
        towerRadiusDamage.SetActive(false);
    }
    
    public virtual void SetTransparent(bool available)
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

    public virtual void SetNormal()
    {
        TurnOffShowRadiusDamage();
        renderer.material.color = Color.white;
    }
    
    public virtual void DetectEnemiesAroundTower(List<GameObject> enemies)
    {

    }
    
    public virtual IEnumerator StartAttack()
    {
        yield return null;
    }
    
    public virtual void DeleteEnemyFromList(EnemyController _enemy)
    {
        for (int i = 0; i < enemiesAroundTower.Count; i++)
        {
            if (_enemy.gameObject == enemiesAroundTower[i])
            {
                enemiesAroundTower.Remove(enemiesAroundTower[i]);
            }
        }
        
    }
}
