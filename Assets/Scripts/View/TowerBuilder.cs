using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static TowerBuilder Instance;

    [SerializeField] private List<TowerSide> grid;
    [SerializeField] private List<ISkill> skills;

    public List<ITower> towersOnScreen;
    public ITower currentTower;

    private void Awake()
    {
        Instance = this;
       
    }

    public void SetCurrentTower(ITower _tower)
    {
        if (currentTower != null)
            Destroy(currentTower.gameObject);
        
        currentTower = Instantiate(_tower);
        ShowAllTowersRadiusDamage();
    }

    private void ShowAllTowersRadiusDamage()
    {
        for (int i = 0; i < towersOnScreen.Count; i++)
        {
            towersOnScreen[i].ShowRadiusDamage();
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
        
        currentTower.SetSkill(currentTower.tower.type);
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
