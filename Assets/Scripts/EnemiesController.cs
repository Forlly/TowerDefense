using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject[] typeOfEnemies;
    [SerializeField] private GameObject[] wayPoints;
    public List<GameObject> enemies;
    [SerializeField] private int maxCountOfEnemiesOnScreen;
    [SerializeField] private int totalCountOfEnemies;
    [SerializeField] private int enemiesPerSpawn;

    private int crntCountOfEnemiesOnScreen = 0;
    void Awake()
    {
        StartCoroutine(Spawn(enemiesPerSpawn, crntCountOfEnemiesOnScreen, totalCountOfEnemies,
            maxCountOfEnemiesOnScreen, typeOfEnemies[Random.Range(0, typeOfEnemies.Length - 1)]));
        
    }
    
    public IEnumerator Spawn(int objPerSpawn, int objOnScreen, int totalCountOfObj, int maxCountOfObjOnScreen, GameObject obj)
    {
        while (objOnScreen < maxCountOfObjOnScreen)
        {
            Debug.Log(Random.Range(0, typeOfEnemies.Length - 1));
            Debug.Log(typeOfEnemies[Random.Range(0, typeOfEnemies.Length - 1)]);
            enemies.Add(Instantiate(typeOfEnemies[Random.Range(0, typeOfEnemies.Length - 1)], spawner.transform.position, Quaternion.identity));
            enemies[enemies.Count - 1].GetComponent<EnemyController>().wayPoints = wayPoints;
            objOnScreen++;
            Debug.Log(objOnScreen);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    
}
