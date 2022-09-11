using UnityEngine.EventSystems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TowerBuilder towerBuilder;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

                if (hit.collider && hit.collider.tag == "TowerSide")
                {
                    TowerSide towerSide = hit.collider.gameObject.GetComponent<TowerSide>();
                    if (towerSide.isFull == false)
                    {
                        towerBuilder.PlaceTower(hit, towerSide);
                    }
                }
            }
        }
    }
}
