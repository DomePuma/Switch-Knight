using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public MakeButton player;
    [SerializeField] private EnemyManager currentEnemy; 

    float playerAtk, playerDef;
    float enemyDef, enemyAtk;
    [SerializeField] float MulUp = 1.2f, MulDown = 0.8f, MulNeutre = 1f;
    [SerializeField] float DmgModificator;
    float DmgMod;
    float Dmg;

    int actionPoint = 2;
    public void Attack(EnemyStats enemy)
    {
        playerAtk = player.currentPlayer.GetComponentInChildren<PlayerStats>().player.attack;
        enemyDef = enemy.GetComponent<EnemyStats>().enemy.defense;

        if(player.currentPlayer.GetComponentInChildren<PlayerStats>().player.playerName != "Edward")
        {
            player.currentPlayer.GetComponentInChildren<PlayerStats>().player.SwitchArme(3);
        }
        
        if(actionPoint > 0)
        {
            switch(player.currentPlayer.GetComponentInChildren<PlayerStats>().player.typeArmes)
            {
                case null:
                    CalculDmgAlly(enemy, MulNeutre);
                    break;
                case "Ciseaux":
                    switch(enemy.tag)
                    {
                        case "Vegetal":
                            CalculDmgAlly(enemy, MulUp);
                            break;
                        case "Mineral":
                            CalculDmgAlly(enemy, MulDown);
                            break;
                        case "Animal":
                            CalculDmgAlly(enemy, MulNeutre);
                            break;
                    }
                    break;
                case "Pioche":
                    switch(enemy.tag)
                    {
                        case "Vegetal":
                            CalculDmgAlly(enemy, MulNeutre);
                            break;
                        case "Mineral":
                            CalculDmgAlly(enemy, MulUp);
                            break;
                        case "Animal":
                            CalculDmgAlly(enemy, MulDown);
                            break;
                    }
                    break;
                case "Marteau":
                    switch(enemy.tag)
                    {
                        case "Vegetal":
                            CalculDmgAlly(enemy, MulDown);
                            break;
                        case "Mineral":
                            CalculDmgAlly(enemy, MulNeutre);
                            break;
                        case "Animal":
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
        // Debug.Log(affinity);
        // Debug.Log("Dmg : " + Dmg);
        // Debug.Log("DmgMod : " + DmgMod);
        // Debug.Log("DmgMod int: " + (int)DmgMod);
        enemy.GetComponent<EnemyStats>().enemy.TakeDmg((int)DmgMod);
        actionPoint = actionPoint--;
    }
    public void Switch(int typeWeapon)
    {
        player.currentPlayer.GetComponentInChildren<PlayerStats>().player.SwitchArme(typeWeapon);
    }
    public void LevelUP(int level)
    {
        player.currentPlayer.GetComponentInChildren<PlayerStats>().player.level_up_stat(level);
    }
    public void AttackEnemy(EnemyStats enemy, float buff)
    {
        enemyAtk = enemy.enemy.attack;
        playerDef = player.currentPlayer.GetComponentInChildren<PlayerStats>().player.defense;
        CalculDmgEnemy(player.currentPlayer.GetComponentInChildren<PlayerStats>(), buff);
    }
    
    private void CalculDmgEnemy(PlayerStats player, float buff)
    {
        Dmg = (enemyAtk*(100/(playerDef + 100)));
        DmgMod = Dmg * buff;
        player.GetComponent<PlayerStats>().player.TakeDmg((int)DmgMod);
    }
}