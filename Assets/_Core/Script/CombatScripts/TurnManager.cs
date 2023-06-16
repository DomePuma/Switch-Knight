using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject uiPlayer;
    [SerializeField] EnemyAction enemyAction;
    [SerializeField] EnemyManager enemyManager;
    TransfereData transfereData;
    PlayerStats[] players;
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

    private void OnEnable() 
    {
        transfereData = FindObjectOfType<TransfereData>();
    }
    private void Start()
    {
        players = FindObjectsOfType<PlayerStats>();
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
        if(transfereData.enemyStartFight)
        {
            uiPlayer.SetActive(false);
            enemyAction.EnemyFirstTurn();
            hasEnemyAtk = true;
        }
        else
        {
            uiPlayer.SetActive(false);
            enemyAction.EnemyTurn();
            hasEnemyAtk = true;
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
    }
    private void CheckCooldown()
    {
        for(int i = 0; i < enemyAction.enemy.Ennemis.Count; i++)
        {
            if(enemyAction.enemy.Ennemis[i].enemy.isInDefense == true)
            {
                if(enemyAction.enemy.Ennemis[i].enemy.hasCooldownDef == false) 
                {
                    enemyAction.enemy.Ennemis[i].enemy.cooldownDef = 1;
                    enemyAction.enemy.Ennemis[i].enemy.hasCooldownDef = true;
                }
                if(enemyAction.enemy.Ennemis[i].enemy.isInDefense == true && enemyAction.enemy.Ennemis[i].enemy.cooldownDef == 0)
                {
                    enemyAction.currentEnemy.enemy.defense -= 100;
                    enemyAction.enemy.Ennemis[i].enemy.isInDefense = false;
                    enemyAction.enemy.Ennemis[i].enemy.hasCooldownDef = false;
                } 
                if(enemyAction.enemy.Ennemis[i].enemy.cooldownDef != 0) enemyAction.enemy.Ennemis[i].enemy.cooldownDef--;
                if(enemyAction.enemy.Ennemis[i].enemy.cooldownDef < 0) enemyAction.enemy.Ennemis[i].enemy.cooldownDef = 0;         
            }
        }
        if(hasAtkBuff)
        {
            enemyAction.attackScript.dmgModificator = atkBuffPower;
            if(atkBuffCooldown != 0)
            {     
                atkBuffCooldown--;
            }
            else
            {
                hasAtkBuff = false;
                enemyAction.attackScript.dmgModificator = 1;
            }
        }
        for(int i = 0; i < players.Length; i++)
        {
            players[i].player.isInvincible = false;
        }
        if(hasDefBuff)
        {
            enemyAction.attackScript.dmgModificatorEnemy = defBuffPower;
            if(defBuffCooldown != 0)
            {     
                defBuffCooldown--;
            }
            else
            {
                hasDefBuff = false;
                enemyAction.attackScript.dmgModificatorEnemy = 1;
            }
        }
    }
    public bool CheckEnemyDeath()
    {
        if(enemyManager.nbEnnemisRestants == 0)
        {
            return true;
        }
        else return false;
    }
}
