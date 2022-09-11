using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static TowerBuilder Instance;
    private GameObject currentTower;

    private void Awake()
    {
        Instance = this;
    }

    public void SetCurrentTower(GameObject towerObj)
    {
        currentTower = towerObj;
    }

    public void PlaceTower(RaycastHit2D hit, TowerSide towerSide)
    {
        if (currentTower != null)
        {
            GameObject newTower = Instantiate(currentTower);
            Debug.Log(currentTower);
            Debug.Log(hit);
            newTower.transform.position = hit.transform.position;

            towerSide.isFull = true;
            currentTower = null;
        }
        
    }
}
