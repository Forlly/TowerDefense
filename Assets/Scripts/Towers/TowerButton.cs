using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Tower towerScrptObject;
    [SerializeField] public GameObject towerObject;

    [SerializeField] private Image towerImage;
    private void Start()
    {
        towerImage.sprite = towerScrptObject.sprite;
        towerObject = towerScrptObject.towerPrefab;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TowerBuilder.Instance.SetCurrentTower(towerObject);
    }
}
