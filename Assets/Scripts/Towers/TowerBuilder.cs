using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static TowerBuilder Instance;
    public Vector2Int GridSize = new Vector2Int(10, 10);

    [SerializeField] private List<TowerSide> grid;
    [SerializeField] private List<GameObject> pathTile;
    public TowerBuilding currentTower;

    private void Awake()
    {
        Instance = this;
       
    }
    

    public void SetCurrentTower(TowerBuilding towerObj)
    {
        if (currentTower != null)
            Destroy(currentTower.gameObject);
        
        currentTower = Instantiate(towerObj);
    }

    public void PlaceTower(TowerSide towerSide, int x, int y)
    {
        if (!IsPlaceAvailable(x, y)) return;
        
        Debug.Log(IsPlaceAvailable(x, y));
        currentTower.SetNormal();
        currentTower = null;
        towerSide.isFull = true;
    }

    private bool IsPlaceAvailable(int x, int y)
    {
        int available = 0;
        for (int i = 0; i < grid.Count; i++)
        {
            if (grid[i].transform.position == new Vector3(x - currentTower.Size.x + 1,y - currentTower.Size.y + 1,0)
                || grid[i].transform.position == new Vector3(x + currentTower.Size.x - 1,y + currentTower.Size.y - 1,0))
            {
                if (!grid[i].isFull)
                {
                    available++;
                }
            }
        }

        if (available == 1)
        {
            for (int i = 0; i < pathTile.Count; i++)
            {
                if (pathTile[i].transform.position == 
                    new Vector3(x + currentTower.Size.x - 1,y + currentTower.Size.y - 1,0)
                    || pathTile[i].transform.position == 
                    new Vector3(x - currentTower.Size.x + 1,y - currentTower.Size.y + 1,0))
                {
                    available++;
                }
            }
            
        }

        if (available == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
