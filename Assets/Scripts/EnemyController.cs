using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private GameObject[] wayPoints;
    private int currentPoint = 0;
    void Start()
    {
        StartCoroutine(Move(wayPoints[currentPoint].transform.position));
    }

    private IEnumerator Move(Vector3 pos)
    {
        float step = 0.008f;
        
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
