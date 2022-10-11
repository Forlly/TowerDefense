using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerView : MonoBehaviour
{
    [SerializeField] private GameObject towerRadiusDamage;
    [SerializeField] private Renderer renderer;
    
    public virtual void ShowRadiusDamage()
    {
        towerRadiusDamage.transform.localScale = new Vector3(tower.radiusDamage * 2, tower.radiusDamage * 2,
            towerRadiusDamage.transform.localScale.z);
        towerRadiusDamage.SetActive(true);
    }
    
    public virtual void TurnOffShowRadiusDamage()
    {
        towerRadiusDamage.SetActive(false);
    }
    
    public virtual void SetTransparent(bool available)
    {
        ShowRadiusDamage();
        if (available)
        {
            renderer.material.color = new Color(0f, 1f, 0f, 0.7f);
        }
        else
        {
            renderer.material.color = new Color(1f, 0f, 0f, 0.7f);
        }
    }

    public virtual void SetNormal()
    {
        TurnOffShowRadiusDamage();
        renderer.material.color = Color.white;
    }
}
