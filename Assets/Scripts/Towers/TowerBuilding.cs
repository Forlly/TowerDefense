using System;
using UnityEngine;

public class TowerBuilding : MonoBehaviour
{
    public Vector2Int Size = Vector2Int.one;
    
    [SerializeField] private Renderer renderer;


    public void SetTransparent(bool available)
    {
        if (available)
        {
            renderer.material.color = new Color(0f, 1f, 0f, 0.7f);
        }
        else
        {
            renderer.material.color = new Color(1f, 0f, 0f, 0.7f);
        }
    }

    public void SetNormal()
    {
        renderer.material.color = Color.white;
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 0.29f);
                Gizmos.DrawCube(transform.position + new Vector3(i,j,0), new Vector3(1,1,0));
            }
        }
    }
}
