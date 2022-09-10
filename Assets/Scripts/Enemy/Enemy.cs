using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject
{
    public int id;
    public string name;
    public Sprite sprite;
    public int health;
    public EnemyType type;
    public float speed;
    public int damage;
}

public enum EnemyType
{
    simple,
    boss
}