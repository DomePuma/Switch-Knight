using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public PlayerStat player = new PlayerStat("");


    public void Start()
    {
        if(this.gameObject.tag != "Gray")
        {
            player.typeArmes = player.SwitchArme(3);
        }
        else
        {
            player.typeArmes = player.SwitchArme(0);
        }
    }
    bool death = false;
    private void Awake() 
    {
        if(player.playerName == null||player.playerName == "")
        {
            Debug.Break();
        }
    }
    private void Update() 
    {
        
        if(player.health <= 0)
        {
            death = true;
        }
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
    [SerializeField] internal float baseHealth = 10;
    [SerializeField] internal float baseAttack = 5;
    [SerializeField] internal float baseDefense = 4;
    
}
    
[System.Serializable]
public class PlayerStat:Basestat
{
    [Header("Autres Stats")]
    public static string[] armes = {"Ciseaux", "Pioche", "Marteau", null};
    public string typeArmes;

    [SerializeField] internal string playerName ="";
    public float health, attack, defense; 
    [SerializeField] internal float level=1;

    [Header("Level Up Stats")]
    [SerializeField] internal float healthUp;
    [SerializeField] internal float attackUp;
    [SerializeField] internal float defenseUp;

    public PlayerStat(string name)
    {
        this.playerName = name;
        this.health = this.baseHealth;
        this.attack = this.baseAttack;
        this.defense = this.baseDefense;
    }
    public string SwitchArme(int id)
    {

        return typeArmes = armes[id];
    }
    public void level_up_stat(float up_level)
    {
        this.level = this.level+up_level;
        this.health = this.health + up_level*healthUp;
        this.attack = this.attack + up_level*attackUp;
        this.defense = this.defense + up_level*defenseUp;
    }
}
