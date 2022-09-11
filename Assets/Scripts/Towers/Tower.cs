using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Tower")]
public class Tower : ScriptableObject
{
    public int id;
    public string name;
    public Sprite sprite;
    public TowerType type;
    public GameObject towerPrefab;
    public int health;
    public int speed;
    public int damage;
}

public enum TowerType
{
    simple,
    freez,
    moreDamage
}