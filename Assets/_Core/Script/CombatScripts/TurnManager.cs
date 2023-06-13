using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject uiPlayer;
    [SerializeField] EnemyAction enemyAction;
    public int pA = 0;
    private bool hasEnemyAtk = false;
    public bool firstTurnPass = false;
    public int nbTurn;
    private void Start()
    {

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
        enemyAction.EnemyTurn();
        hasEnemyAtk = true;
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
        for(int j = 0; j < enemyAction.enemy.Ennemis.Count; j++)
        {
            if(enemyAction.enemy.Ennemis[j].enemy.isInDefense == true)
            {
                if(enemyAction.enemy.Ennemis[j].enemy.hasCooldownDef == false) 
                {
                    enemyAction.enemy.Ennemis[j].enemy.cooldownDef = 1;
                    enemyAction.enemy.Ennemis[j].enemy.hasCooldownDef = true;
                }
                if(enemyAction.enemy.Ennemis[j].enemy.isInDefense == true && enemyAction.enemy.Ennemis[j].enemy.cooldownDef == 0)
                {
                    enemyAction.currentEnemy.enemy.defense -= 100;
                    enemyAction.enemy.Ennemis[j].enemy.isInDefense = false;
                    enemyAction.enemy.Ennemis[j].enemy.hasCooldownDef = false;
                } 
                if(enemyAction.enemy.Ennemis[j].enemy.cooldownDef != 0) enemyAction.enemy.Ennemis[j].enemy.cooldownDef--;
                if(enemyAction.enemy.Ennemis[j].enemy.cooldownDef < 0) enemyAction.enemy.Ennemis[j].enemy.cooldownDef = 0;         
            }
        }
    }
}
