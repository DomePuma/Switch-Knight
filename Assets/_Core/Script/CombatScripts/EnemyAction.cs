using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    EnemyManager enemyManager;
    AttackScript attackScript;
    [SerializeField] private float attackBooste = 1.2f;
    public EnemyStats currentEnemy;
    private int nbTurnSA;
    SpellManager spellManager;
    TurnManager turnManager;
    public GameObject currentEnemyPosition;
    public GameObject currentEnemyGameObject;

    private void Awake() 
    {
        spellManager = FindObjectOfType<SpellManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        attackScript = FindObjectOfType<AttackScript>();
        turnManager = FindObjectOfType<TurnManager>();
    }
    private EnemyStats ChoseEnemy()
    {

        int enemyRandom = Random.Range(0, enemyManager.enemis.Count);
        currentEnemyGameObject = enemyManager.enemis[enemyRandom].gameObject;
        EnemyStats enemyAtk = enemyManager.enemis[enemyRandom];
        currentEnemyPosition = enemyManager.emplacementEnnemis[enemyRandom];
        if(enemyAtk.enemy.health <= 0)
        {
            return ChoseEnemy();
        }
        else return enemyAtk;
    }
    public void EnemyTurn()
    {
            if(turnManager.allEnemiesDead == true)
            {
                turnManager.CheckEnemyDeath();
            }
            else currentEnemy = ChoseEnemy();
            //Attaque chargée
            if(nbTurnSA == 3)
            {
                if(attackScript.player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray" && spellManager.isInGuard == true)
                {
                    attackScript.AttackEnemyRiposte(currentEnemy, attackBooste);
                    currentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                    nbTurnSA = 0;
                    Debug.Log("RiposteAtkFort");
                } 
                else 
                {
                    attackScript.AttackEnemy(currentEnemy, attackBooste);
                    currentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                    nbTurnSA = 0;                
                }    
            }
            else
            {
                switch(Random.Range(0,2))
                {
                    case 0:
                    {
                        //Attaque
                        if(attackScript.player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray" && spellManager.isInGuard == true)
                        {
                            attackScript.AttackEnemyRiposte(currentEnemy, 1f);
                            currentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                            nbTurnSA++;
                            Debug.Log("RiposteAtk");
                        } 
                        else 
                        {
                            attackScript.AttackEnemy(currentEnemy, 1f);
                            currentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                            nbTurnSA++;
                        }
                        break;
                    }
                    case 1:
                    {
                        //Defense
                        currentEnemy.enemy.defense += 100;
                        currentEnemy.enemy.isInDefense = true;
                        currentEnemy.enemy.currentAnimator.SetTrigger("Defense");
                        nbTurnSA++;
                        if(attackScript.player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray") attackScript.player.GetComponentInChildren<Animator>().SetTrigger("!EnemyAtk");
                        break;
                    }
                }
            }
        }
    public void EnemyFirstTurn()
    {
        currentEnemy = ChoseEnemy();
        
        if(currentEnemy.enemy.dead)
        {
            ChoseEnemy();
        }
        else
        {
            //Attaque chargée
            if(nbTurnSA == 3)
            {
                attackScript.AttackEnemyRiposte(currentEnemy, attackBooste);
                currentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                nbTurnSA = 0;
            }
            else
            {
                switch(Random.Range(0,2))
                {
                    case 0:
                    {
                        //Attaque
                        attackScript.AttackEnemy(currentEnemy, 1f);
                        currentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                        nbTurnSA++;
                        break;
                    }
                    case 1:
                    {
                        //Defense
                        currentEnemy.enemy.defense += 100;
                        currentEnemy.enemy.isInDefense = true;
                        currentEnemy.enemy.currentAnimator.SetTrigger("Defense");
                        nbTurnSA++;
                        break;
                    }
                }
            }
        }
    }  
}
