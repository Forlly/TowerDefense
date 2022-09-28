using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Tower towerScrptObject;
    [SerializeField] public SimpleTowerBuilding simpleTowerObject;

    [SerializeField] private Image towerImage;
    private void Start()
    {
        towerImage.sprite = towerScrptObject.sprite;
        simpleTowerObject = towerScrptObject.simpleTowerPrefab;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TowerBuilder.Instance.SetCurrentTower(simpleTowerObject);
    }
}
