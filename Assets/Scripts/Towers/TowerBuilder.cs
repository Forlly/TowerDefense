using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static TowerBuilder Instance;

    [SerializeField] private List<TowerSide> grid;
    [SerializeField] private List<GameObject> pathTile;
    
    public List<TowerBuilding> towersOnScreen;
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
        Debug.Log(towersOnScreen.Count);
        ShowAllTowersRadiusDamage();
    }

    private void ShowAllTowersRadiusDamage()
    {
        for (int i = 0; i < towersOnScreen.Count; i++)
        {
            towersOnScreen[i].ShowRadiusDamage();
            Debug.Log(towersOnScreen[i]);
        }
    }
    
    private void TurnOffShowAllTowersRadiusDamage()
    {
        for (int i = 0; i < towersOnScreen.Count; i++)
        {
            towersOnScreen[i].TurnOffShowRadiusDamage();
        }
    }

    public void PlaceTower(TowerSide towerSide, int x, int y)
    {
        if (!IsPlaceAvailable(x, y))
        {
            return;
        }
        
        towersOnScreen.Add(currentTower);
        TurnOffShowAllTowersRadiusDamage();
        StartCoroutine(currentTower.StartAttack());
        
        currentTower.SetNormal();
        currentTower = null;
        towerSide.isFull = true;
    }

    public bool IsPlaceAvailable(int x, int y)
    {
        for (int i = 0; i < grid.Count; i++)
        {
            if (grid[i].transform.position == new Vector3(x ,y,0))
            {
                return !grid[i].isFull;
            }
        }


        return false;
    }
}
