using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject uiPlayer;
    EnemyAction enemyAction;
    EnemyManager enemyManager;
    TransfereData transfereData;
    AttackScript attackScript;
    PlayerStats[] playerStats;
    EnemyStats[] enemyStats;
    ChosePlayer chosePlayer;
    public int pA = 0;
    private bool hasEnemyAtk = false;
    public bool firstTurnPass = false;
    public int nbTurn;    

    [Header("Paramètres des buff d'attaque")]
    public bool hasAtkBuff;
    public int atkBuffCooldown;
    [SerializeField] float atkBuffPower;

    [Header("Paramètres des buffs de defense")]
    public bool hasDefBuff;
    public int defBuffCooldown;
    [SerializeField] float defBuffPower;


    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        playerStats = FindObjectsOfType<PlayerStats>();
        enemyStats = FindObjectsOfType<EnemyStats>();
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyAction = FindObjectOfType<EnemyAction>();
        attackScript = FindObjectOfType<AttackScript>();
        chosePlayer = FindObjectOfType<ChosePlayer>();
    }
    private void Update() 
    {
        if(pA <= 0 && hasEnemyAtk == false)
        {
            uiPlayer.SetActive(false);
        }

    }
    public void PassTurn()
    {
        CheckEnemyDeath();
        if(enemyManager.nbEnnemisRestants == 0)
        {
            enemyManager.EndFight();
        }
        else
        {
            if(transfereData.enemyStartFight)
            {
                uiPlayer.SetActive(false);
                enemyAction.EnemyFirstTurn();
                hasEnemyAtk = true;
                transfereData.enemyStartFight = false;
            }
            else
            {
                uiPlayer.SetActive(false);
                enemyAction.EnemyTurn();
                hasEnemyAtk = true;
            } 
        }
         
    }
    public void EndTurnEnemy()
    {
        uiPlayer.SetActive(true);
        pA = 2;
        hasEnemyAtk = false;
        if(!firstTurnPass) firstTurnPass = true;
        else nbTurn++;
        FindObjectOfType<SpellManager>().isInGuard = false;
        CheckCooldown();
        CheckPlayersDeath();
    }
    private void CheckCooldown()
    {
        for(int i = 0; i < enemyManager.enemis.Count; i++)
        {
            if(enemyManager.enemis[i].enemy.isInDefense == true)
            {
                if(enemyManager.enemis[i].enemy.hasCooldownDef == false) 
                {
                    enemyManager.enemis[i].enemy.cooldownDef = 1;
                    enemyManager.enemis[i].enemy.hasCooldownDef = true;
                }
                if(enemyManager.enemis[i].enemy.isInDefense == true && enemyManager.enemis[i].enemy.cooldownDef == 0)
                {
                    enemyAction.currentEnemy.enemy.defense -= 100;
                    enemyManager.enemis[i].enemy.isInDefense = false;
                    enemyManager.enemis[i].enemy.hasCooldownDef = false;
                } 
                if(enemyManager.enemis[i].enemy.cooldownDef != 0) enemyManager.enemis[i].enemy.cooldownDef--;
                if(enemyManager.enemis[i].enemy.cooldownDef < 0) enemyManager.enemis[i].enemy.cooldownDef = 0;         
            }
        }
        if(hasAtkBuff)
        {
            attackScript.dmgModificator = atkBuffPower;
            if(atkBuffCooldown != 0)
            {     
                atkBuffCooldown--;
            }
            else
            {
                hasAtkBuff = false;
                attackScript.dmgModificator = 1;
            }
        }
        for(int i = 0; i < playerStats.Length; i++)
        {
            playerStats[i].player.isInvincible = false;
        }
        if(hasDefBuff)
        {
            attackScript.dmgModificatorEnemy = defBuffPower;
            if(defBuffCooldown != 0)
            {     
                defBuffCooldown--;
            }
            else
            {
                hasDefBuff = false;
                attackScript.dmgModificatorEnemy = 1;
            }
        }
    }
    public void CheckEnemyDeath()
    {
        for(int i = 0; i < enemyStats.Length; i++)
        {
            if(enemyStats[i].enemy.health <= 0 && enemyStats[i].enemy.dead != true)
            {
                Debug.Log("Dead");
                enemyStats[i].enemy.dead = true;
                enemyManager.xp += enemyStats[i].enemy.exp;
                enemyManager.EnemyDeath();
            }
        }
    }
    private void CheckPlayersDeath()
    {
        for(int i = 0; i < playerStats.Length; i++)
        {
            if(playerStats[i].player.health <= 0 && playerStats[i].player.dead != true)
            {
                Debug.Log("dead");
                playerStats[i].player.dead = true;
                chosePlayer.PlayerDeath();
            }
        }
    }
}
