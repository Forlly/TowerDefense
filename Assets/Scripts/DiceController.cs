using System;
using System.Collections;
using UnityEngine;

public class DiceController : MonoBehaviour, IDiceController
{

    [SerializeField] private Enemy enemy;
    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        sprite.sprite = this.enemy.sprite;
        IEnemyController enemy = FindObjectOfType<EnemyController>();
        StartCoroutine(Attacke(enemy));
    }

    public Enemy GetDice()
    {
        return enemy;
    }

    public void SetDice(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public IEnumerator Attacke(IEnemyController enemy)
    {
        int damage = this.enemy.damage;
        
        /*if (this.enemy.value > 1)
        {
            damage = (int)Mathf.Ceil(this.enemy.damage * (this.enemy.value / 2));
        }

        enemy.ReceiveDamage(this.enemy.damage * damage);
        Debug.Log(damage);*/
        yield return new WaitForSeconds(this.enemy.damage/10);
        StartCoroutine(Attacke(enemy));
    }
}
