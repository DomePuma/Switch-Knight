using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject player;

    float playerAtk, playerDef;
    float enemyDef, enemyAtk;
    [SerializeField] float mulUp = 1.2f, mulDown = 0.8f, mulNeutre = 1f;
    [SerializeField] public float dmgModificator = 1;
    float dmgMod;
    float dmg;
    public float dmgModificatorEnemy = 1;
    TurnManager turnManager;
    public GameObject rayon;
    
    private void Awake() 
    {
        turnManager = FindObjectOfType<TurnManager>();
    }
    private void Start() 
    {
        player = FindObjectOfType<ChosePlayer>().player;
    }
    private void Update() {
        player = FindObjectOfType<ChosePlayer>().player;
    }
    public void Attack(EnemyStats enemy)
    {
        playerAtk = player.GetComponentInChildren<PlayerStats>().player.attack;
        enemyDef = enemy.enemy.defense;

        
        if(turnManager.pA > 0)
        {
            switch(player.GetComponentInChildren<PlayerStats>().player.typeArmes)
            {
                case TypeArme.Autre:
                    CalculDmgAlly(enemy, mulNeutre);
                    break;
                case TypeArme.Ciseaux:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, mulUp);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, mulDown);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, mulNeutre);
                            break;
                    }
                    break;
                case TypeArme.Pioche:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, mulNeutre);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, mulUp);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, mulDown);
                            break;
                    }
                    break;
                case TypeArme.Marteau:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, mulDown);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, mulNeutre);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, mulUp);
                            break;
                    }
                    break;
            }
        }
    }
    private void CalculDmgAlly(EnemyStats enemy, float affinity)
    {
        enemy.gameObject.GetComponentInChildren<Animator>().SetTrigger("Hurt");
        dmg = (playerAtk*(100/(enemyDef + 100)))*affinity;
        dmgMod = dmg * dmgModificator;
        turnManager.pA = 0;
        enemy.enemy.TakeDmg(dmgMod);
    }
    public void AttackEnemyRiposte(EnemyStats enemy, float buff)
    {
        enemyAtk = enemy.enemy.attack;
        playerDef = player.GetComponentInChildren<PlayerStats>().player.defense;
        CalculRipostDmgEnemy(enemy, buff);
    }
    private void CalculRipostDmgEnemy(EnemyStats enemy, float buff)
    {
        player.GetComponentInChildren<Animator>().SetTrigger("EnnemiAtk");
        dmg = (enemyAtk*(100/(playerDef + 100)));
        dmgMod = ((dmg * buff) * dmgModificatorEnemy) * .8f;
        player.gameObject.GetComponentInChildren<PlayerStats>().player.TakeDmg(dmgMod);
        CalculRiposteDmg(enemy);
    }
    private void CalculRiposteDmg(EnemyStats enemy)
    {
        
        float enemyDefTemp = enemy.enemy.defense;
        float playerAtkTemp = player.GetComponentInChildren<PlayerStats>().player.attack;
        dmg = (playerAtkTemp*(100/(enemyDefTemp + 100)));
        dmgMod = (dmg * dmgModificator) * .6f;
        enemy.enemy.TakeDmg(dmgMod);
    }
    public void LevelUP(int level)
    {
        player.GetComponentInChildren<PlayerStats>().player.Level_up_stat(level);
    }
    public void AttackEnemy(EnemyStats enemy, float buff)
    {
        enemyAtk = enemy.enemy.attack;
        playerDef = player.GetComponentInChildren<PlayerStats>().player.defense;
        CalculDmgEnemy(buff);
    }
    
    private void CalculDmgEnemy(float buff)
    {
        dmg = (enemyAtk*(100/(playerDef + 100)));
        dmgMod = (dmg * buff) * dmgModificatorEnemy;
        Debug.Log(dmgMod);
        player.gameObject.GetComponentInChildren<PlayerStats>().player.TakeDmg((int)dmgMod);
    }
    public GameObject MajAtk()
    {
        return GameObject.FindGameObjectWithTag("MajAtk");
    }
}