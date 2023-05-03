using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerStat player = new PlayerStat("");

    private void Awake() 
    {
        if(player.playerName == null||player.playerName == "")
        {
            Debug.Break();
        }
    }
    public void ShowStats()
    {
        Debug.Log("Le joueur s'appelle " + player.playerName);
        Debug.Log("Le joueur a " + player.health + " HPs");
        Debug.Log("Le joueur a " + player.attack + " points d'attaque");
        Debug.Log("Le joueur a " + player.defense + " points de défense");
        Debug.Log("Le joueur est level " + player.level);
    }
    public void LevelUP()
    {
        player.level_up_stat(1);
    }
}
[System.Serializable]
public class Basestat
{
    [Header("Stats de base")]
    [SerializeField] internal int baseHealth = 10;
    [SerializeField] internal int baseAttack = 5;
    [SerializeField] internal int baseDefense = 4;
    
}
    
[System.Serializable]
class PlayerStat:Basestat
{
    [Header("Autres Stats")]
    [SerializeField] internal string playerName ="";
    internal int health, attack, defense; 
    [SerializeField] internal int level=1;

    [Header("Level Up Stats")]
    [SerializeField] internal int healthUp;
    [SerializeField] internal int attackUp;
    [SerializeField] internal int defenseUp;

    public PlayerStat(string name)
    {
        this.playerName = name;
        this.health = this.baseHealth;
        this.attack = this.baseAttack;
        this.defense = this.baseDefense;
    }
    
    public void level_up_stat(int up_level)
    {
        this.level = this.level+up_level;
        this.health = this.health + up_level*healthUp;
        this.attack = this.attack + up_level*attackUp;
        this.defense = this.defense + up_level*defenseUp;
    }
}
