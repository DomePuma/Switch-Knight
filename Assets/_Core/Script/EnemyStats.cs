using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public EnemyStat enemy = new EnemyStat("");
    [SerializeField] public GameObject selectLight;
}
[System.Serializable]
public class BaseEnemyStat
{
    [Header("Stats de base")]
    [SerializeField] internal float baseHealth = 10;
    [SerializeField] internal float baseAttack = 5;
    [SerializeField] internal float baseDefense = 4;
    [SerializeField] internal float baseExp = 10;
    
}
    
[System.Serializable]
public class EnemyStat:BaseEnemyStat
{
    [Header("Autres Stats")]
    [SerializeField] internal string playerName ="";
    public float health, attack, defense, exp;
    [SerializeField] internal float level=1;

    [Header("Level Up Stats")]
    [SerializeField] internal float healthUp;
    [SerializeField] internal float attackUp;
    [SerializeField] internal float defenseUp;
    [SerializeField] internal float expUp;
    public EnemyStat(string name)
    {
        this.playerName = name;
        this.health = this.baseHealth;
        this.attack = this.baseAttack;
        this.defense = this.baseDefense;
        this.exp = this.baseExp;
    }
    public void level_up_stat(float up_level)
    {
        this.level = this.level+up_level;
        this.health = this.health + up_level*healthUp;
        this.attack = this.attack + up_level*attackUp;
        this.defense = this.defense + up_level*defenseUp;
        this.exp = this.exp + up_level*expUp;
    }
    public void TakeDmg(int dmg)
    {
        this.health = this.health - dmg;
    }
}
