using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    private List<GameObject> objects;
    
    private void Awake()
    {
        Instance = this;
    }

    public List<GameObject> Spawn()
    {

        return objects;
    }

    public IEnumerator Spawn(int objPerSpawn, int objOnScreen, int totalCountOfObj, int maxCountOfObjOnScreen, 
        List<GameObject> objcts, GameObject obj)
    {
        objects = objcts;
        while (objOnScreen < maxCountOfObjOnScreen)
        {
            objects.Add(Instantiate(obj, transform.position, Quaternion.identity));
            objOnScreen++;
            Debug.Log(objOnScreen);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
