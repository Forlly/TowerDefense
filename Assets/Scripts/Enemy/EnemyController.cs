using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{

    [SerializeField] public GameObject[] wayPoints;
    [SerializeField] private Enemy typeOfEnemy;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int health;

    public float speed;
    
    private int currentPoint = 0;
    
    void Start()
    {
        speed = typeOfEnemy.speed;
        wayPoints = EnemiesController.Instance.wayPoints;
        health = typeOfEnemy.health;
        spriteRenderer.sprite = typeOfEnemy.sprite;
        StartCoroutine(Move(wayPoints[currentPoint].transform.position));
    }

    public void ReceiveDamage(int _damage)
    {
        health -= _damage;
    }

    public bool EnemyKilled(int _damage, ITower simpleTower)
    {
        if (health - _damage <= 0)
        {
            EnemiesController.Instance.DeleteEnemyFromList(gameObject);
            simpleTower.DeleteEnemyFromList(this);
            
            ObjectsPool.Instance.TurnOfObject(gameObject);
            Debug.Log("Delete enemy" + this.gameObject);
            return true;
        }

        return false;
    }

    public IEnumerator Move(Vector3 pos)
    {
        float step = typeOfEnemy.speed;
        
        while (transform.position != pos)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, step);
            yield return null;
        }

        currentPoint++;
        if (currentPoint < wayPoints.Length)
        {
            StartCoroutine(Move(wayPoints[currentPoint].transform.position));
            yield break;
        }
    }
}
