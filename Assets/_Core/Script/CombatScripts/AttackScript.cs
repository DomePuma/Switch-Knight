using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject player;

    float playerAtk, playerDef;
    float enemyDef, enemyAtk;
    [SerializeField] float MulUp = 1.2f, MulDown = 0.8f, MulNeutre = 1f;
    [SerializeField] float DmgModificator;
    float DmgMod;
    float Dmg;
    [SerializeField] TurnManager turnManager;
    
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
                    CalculDmgAlly(enemy, MulNeutre);
                    break;
                case TypeArme.Ciseaux:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, MulUp);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, MulDown);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, MulNeutre);
                            break;
                    }
                    break;
                case TypeArme.Pioche:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, MulNeutre);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, MulUp);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, MulDown);
                            break;
                    }
                    break;
                case TypeArme.Marteau:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, MulDown);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, MulNeutre);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, MulUp);
                            break;
                    }
                    break;
            }
        }
    }
    private void CalculDmgAlly(EnemyStats enemy, float affinity)
    {
        Dmg = (playerAtk*(100/(enemyDef + 100)))*affinity;
        DmgMod = Dmg * DmgModificator;
        turnManager.pA = 0;
        enemy.enemy.TakeDmg((int)DmgMod);
    }
    public void AttackEnemyRiposte(EnemyStats enemy, float buff)
    {
        enemyAtk = enemy.enemy.attack;
        playerDef = player.GetComponentInChildren<PlayerStats>().player.defense;
        CalculRipostDmgEnemy(enemy, buff);
    }
    private void CalculRipostDmgEnemy(EnemyStats enemy, float buff)
    {
        Debug.Log("CalculRipostDmgEnemy playerDef " + playerDef);
        Dmg = (enemyAtk*(100/(playerDef + 100)));
        DmgMod = (Dmg * buff) * .8f;
        player.GetComponentInChildren<Animator>().SetTrigger("EnnemiAtk");
        player.gameObject.GetComponentInChildren<PlayerStats>().player.TakeDmg((int)DmgMod);
        CalculRiposteDmg(enemy, buff);
    }
    private void CalculRiposteDmg(EnemyStats enemy, float buff)
    {
        
        float enemyDefTemp = enemy.enemy.defense;
        float playerAtkTemp = player.GetComponentInChildren<PlayerStats>().player.attack;
        Dmg = (playerAtkTemp*(100/(enemyDefTemp + 100)));
        Debug.Log("CalculRiposteDmg enemyDefTemp " + enemyDefTemp);
        DmgMod = (Dmg * buff) * .4f;
        Debug.Log("CalculRiposteDmg Dmg " + Dmg);
        enemy.enemy.TakeDmg((int)DmgMod);
        Debug.Log("CalculRiposteDmg DmgMod " + DmgMod);
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
        Dmg = (enemyAtk*(100/(playerDef + 100)));
        DmgMod = Dmg * buff;
        player.gameObject.GetComponentInChildren<PlayerStats>().player.TakeDmg((int)DmgMod);
    }
}