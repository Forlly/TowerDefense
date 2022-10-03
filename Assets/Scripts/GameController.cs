using UnityEngine.EventSystems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TowerBuilder towerBuilder;
    void Update()
    {
        if (towerBuilder.currentTower != null)
        {
            var groundPlane = new Plane(new Vector3(0,0,1), Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.y);

                bool available = true;

                towerBuilder.currentTower.transform.position = new Vector3(x, y, 0);

                if (!towerBuilder.IsPlaceAvailable(x,y))
                {
                    available = false;
                }
                towerBuilder.currentTower.SetTransparent(available);
                
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
                                towerBuilder.PlaceTower(towerSide, x, y);
                            }
                        }
                    }
                }
            }
            
            
        }
    }
    
}
