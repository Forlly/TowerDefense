using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Tower towerScrptObject;
    [SerializeField] public ITower tower;

    [SerializeField] private Image towerImage;
    private void Start()
    {
        towerImage.sprite = towerScrptObject.sprite;
        tower = towerScrptObject.tower;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TowerBuilder.Instance.SetCurrentTower(tower);
    }
}
