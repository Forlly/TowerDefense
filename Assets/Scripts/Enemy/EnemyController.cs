using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{

    [SerializeField] public GameObject[] wayPoints;
    [SerializeField] private Enemy typeOfEnemy;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int health;
    
    private int currentPoint = 0;
    
    void Start()
    {

        wayPoints = EnemiesController.Instance.wayPoints;
        health = typeOfEnemy.health;
        spriteRenderer.sprite = typeOfEnemy.sprite;
        StartCoroutine(Move(wayPoints[currentPoint].transform.position));
    }

    public void ReceiveDamage(int _damage)
    {
        health -= _damage;
        Debug.Log(health);
        
        if (health <= 0)
        {
            EnemiesController.Instance.DeleteEnemyFromList(this.gameObject);
            Destroy(gameObject);
        }
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
