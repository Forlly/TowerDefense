using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static TowerBuilder Instance;

    [SerializeField] private List<TowerSide> grid;

    public List<SimpleTowerBuilding> towersOnScreen;
    public SimpleTowerBuilding currentSimpleTower;

    private void Awake()
    {
        Instance = this;
       
    }

    public void SetCurrentTower(SimpleTowerBuilding simpleTowerObj)
    {
        if (currentSimpleTower != null)
            Destroy(currentSimpleTower.gameObject);
        
        currentSimpleTower = Instantiate(simpleTowerObj);
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
        
        towersOnScreen.Add(currentSimpleTower);
        TurnOffShowAllTowersRadiusDamage();
        StartCoroutine(currentSimpleTower.StartAttack());
        
        currentSimpleTower.SetNormal();
        currentSimpleTower = null;
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
