using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Tower")]
public class Tower : ScriptableObject
{
    public int id;
    public string name;
    public Sprite sprite;
    public TowerType type;
    public SimpleTowerBuilding simpleTowerPrefab;
    public int health;
    public int speed;
    public int damage;
    public float radiusDamage;
}

public enum TowerType
{
    simple,
    freez,
    moreDamage
}