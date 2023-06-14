using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public PlayerStat player = new PlayerStat("");
    private void Awake() 
    {
        if(player.playerName == null||player.playerName == "")
        {
            Debug.Break();
        }
        if(this.gameObject.tag != "Gray")
        {
            player.typeArmes = TypeArme.Autre;
        }
        else
        {
            player.typeArmes = TypeArme.Ciseaux;
        }
    }
    private void Update() 
    {
        if(player.health >= player.maxHealth)
        {
            player.health = player.maxHealth;
        }
        if(player.defense >= player.maxDefense)
        {
            player.defense = player.maxDefense;
        }
        if(player.attack >= player.maxAttack)
        {
            player.attack = player.maxAttack;
        }
    }
    public void LevelUP()
    {
        player.Level_up_stat(1);
    }
}
[System.Serializable]
public class Basestat
{
    [Header("Stats de base")]
    [SerializeField] internal float baseHealth = 10;
    [SerializeField] internal float baseAttack = 5;
    [SerializeField] internal float baseDefense = 4;
}
    
[System.Serializable]
public class PlayerStat:Basestat
{
    [Header("Autres Stats")]
    [SerializeField] ChosePlayer changePlayer;
    public TypeArme typeArmes;
    public Sprite icon;

    [SerializeField] internal string playerName ="";
    
    internal float maxHealth, maxAttack, maxDefense;
    public float health, attack, defense;
    public bool isInvincible;
    public bool dead = false;
    [SerializeField] internal float level=1;

    [Header("Level Up Stats")]
    [SerializeField] internal float healthUp;
    [SerializeField] internal float attackUp;
    [SerializeField] internal float defenseUp;

    public PlayerStat(string name)
    {
        this.playerName = name;
        this.maxHealth = this.baseHealth;
        this.maxAttack = this.baseAttack;
        this.maxDefense = this.baseDefense;
    }
    public void Level_up_stat(float up_level)
    {
        this.level = this.level+up_level;
        this.maxHealth = this.maxHealth + up_level*healthUp;
        this.maxAttack = this.maxAttack + up_level*attackUp;
        this.maxDefense = this.maxDefense + up_level*defenseUp;
        
    }
    private void RefilStats()
    {
        this.health = this.maxHealth;
        this.attack = this.maxAttack;
        this.defense = this.maxDefense;
    }
    public void TakeDmg(int dmg)
    {
        if(!isInvincible)
        {
            this.health = this.health - dmg;
        }
        
        if(health <= 0)
        {
           dead = true;
           changePlayer.PlayerDeath();
        }
    }
}
public enum TypeArme
{
    Marteau,
    Pioche,
    Ciseaux,
    Autre
}
