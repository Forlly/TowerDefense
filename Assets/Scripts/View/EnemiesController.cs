using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] public GameObject[] wayPoints;
    public List<GameObject> enemies;
    [SerializeField] private int maxCountOfEnemiesOnScreen;

    public static EnemiesController Instance;

    private int crntCountOfEnemiesOnScreen = 0;
    void Start()
    {
        Instance = this;
        StartCoroutine(Spawn( crntCountOfEnemiesOnScreen,maxCountOfEnemiesOnScreen));
        
    }

    public void DeleteEnemyFromList(GameObject currentEnemy)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (currentEnemy == enemies[i])
            {
                enemies.Remove(enemies[i]);
            }
        }
    }
    
    public IEnumerator Spawn(int objOnScreen, int maxCountOfObjOnScreen)
    {
        GameObject tmpEnemy;
        
        while (objOnScreen < maxCountOfObjOnScreen)
        {
            tmpEnemy = ObjectsPool.Instance.GetPooledObject();
            enemies.Add(tmpEnemy);
            tmpEnemy.transform.position = spawner.transform.position;
            
            objOnScreen++;

            yield return new WaitForSeconds(0.8f);
        }
        
    }
    
}
