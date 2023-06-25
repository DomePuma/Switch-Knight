using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Image healthBar;

    private void Update() 
    {
        healthBar.fillAmount = (playerStats.player.health/playerStats.player.maxHealth);
    }
}
