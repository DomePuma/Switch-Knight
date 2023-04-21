using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStats _EnemyStats = new EnemyStats();

}

[System.Serializable]
public class EnemyStats{
    [SerializeField] string enemyName;
    [SerializeField] int health;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int experienceLoot; 

}
