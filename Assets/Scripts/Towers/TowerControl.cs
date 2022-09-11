using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] private float timeBeetwenAttacks;
    [SerializeField] private float attackRadius;
    private GameObject projectile;
    private EnemiesController currentEnemy = null;
    private float attackCounter;
    
    
}
