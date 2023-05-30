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
    
    private void Update() {
        player = FindObjectOfType<ChosePlayer>().player;
    }
    public void Attack(EnemyStats enemy)
    {
        playerAtk = player.GetComponentInChildren<PlayerStats>().player.attack;
        enemyDef = enemy.enemy.defense;

        if(player.GetComponentInChildren<PlayerStats>().player.playerName != "Edward")
        {
            player.GetComponentInChildren<PlayerStats>().player.SwitchArme(3);
        }
        
        if(turnManager.pA > 0)
        {
            switch(player.GetComponentInChildren<PlayerStats>().player.typeArmes)
            {
                case null:
                    CalculDmgAlly(enemy, MulNeutre);
                    break;
                case "Ciseaux":
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
                case "Pioche":
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
                case "Marteau":
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
    public void LevelUP(int level)
    {
        player.GetComponentInChildren<PlayerStats>().player.level_up_stat(level);
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