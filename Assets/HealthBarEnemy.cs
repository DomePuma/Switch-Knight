using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] int nbEnemy;
    EnemyStats enemyStats;
    [SerializeField] Image healthBar;
    private void Start() 
    {
        enemyStats = FindObjectOfType<EnemyManager>().enemis[nbEnemy];
    }
    private void Update() 
    {
        healthBar.fillAmount = (enemyStats.enemy.health/enemyStats.enemy.maxHealth);
    }
}
