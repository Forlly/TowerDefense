using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{

    [SerializeField] public GameObject[] wayPoints;
    [SerializeField] private Enemy typeOfEnemy;
    private int currentPoint = 0;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int health;
    void Start()
    {
        health = typeOfEnemy.health;
        spriteRenderer.sprite = typeOfEnemy.sprite;
        StartCoroutine(Move(wayPoints[currentPoint].transform.position));
    }

    public void ReceiveDamage(int _damage)
    {
        health -= _damage;
        Debug.Log(health);
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
