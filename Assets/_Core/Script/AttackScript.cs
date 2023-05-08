using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public MakeButton player;

    float playerAtk;
    float enemyHealth, enemyDef;
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
                    CalculDmg(enemy, MulNeutre);
                    break;
                case "Ciseaux":
                    switch(enemy.tag)
                    {
                        case "Vegetal":
                            CalculDmg(enemy, MulUp);
                            break;
                        case "Mineral":
                            CalculDmg(enemy, MulDown);
                            break;
                        case "Animal":
                            CalculDmg(enemy, MulNeutre);
                            break;
                    }
                    break;
                case "Pioche":
                    switch(enemy.tag)
                    {
                        case "Vegetal":
                            CalculDmg(enemy, MulNeutre);
                            break;
                        case "Mineral":
                            CalculDmg(enemy, MulUp);
                            break;
                        case "Animal":
                            CalculDmg(enemy, MulDown);
                            break;
                    }
                    break;
                case "Marteau":
                    switch(enemy.tag)
                    {
                        case "Vegetal":
                            CalculDmg(enemy, MulDown);
                            break;
                        case "Mineral":
                            CalculDmg(enemy, MulNeutre);
                            break;
                        case "Animal":
                            CalculDmg(enemy, MulUp);
                            break;
                    }
                    break;
            }
        }


    }
    public void Switch(int typeWeapon)
    {
        player.currentPlayer.GetComponentInChildren<PlayerStats>().player.SwitchArme(typeWeapon);
    }
    private void CalculDmg(EnemyStats enemy, float affinity)
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
    public void LevelUP(int level)
    {
        player.currentPlayer.GetComponentInChildren<PlayerStats>().player.level_up_stat(level);
    }
}
