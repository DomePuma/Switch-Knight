using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] public EnemyManager enemy;
    [SerializeField] public AttackScript attackScript;
    [SerializeField] private float attackBooste = 1.2f;
    public EnemyStats currentEnemy;
    private int nbTurnSA;
    SpellManager spellManager;

    private void Start() 
    {
           spellManager = FindObjectOfType<SpellManager>();
    }
    private EnemyStats ChoseEnemy()
    {
        EnemyStats enemyAtk = enemy.Ennemis[Random.Range(0, enemy.Ennemis.Count)];
        if(enemyAtk.enemy.health <= 0)
        {
            return ChoseEnemy();
        }
        else return enemyAtk;
    }
    public void EnemyTurn()
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

                if(attackScript.player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray" && spellManager.isInGuard == true)
                {
                    attackScript.AttackEnemyRiposte(currentEnemy, attackBooste);
                    currentEnemy.enemy.animator.SetTrigger("AttackStrong");
                    nbTurnSA = 0;
                    Debug.Log("RiposteAtkFort");
                } 
                else 
                {
                    attackScript.AttackEnemy(currentEnemy, attackBooste);
                    currentEnemy.enemy.animator.SetTrigger("AttackStrong");
                    
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
                            currentEnemy.enemy.animator.SetTrigger("Attack");
                            nbTurnSA++;
                            Debug.Log("RiposteAtk");
                        } 
                        else 
                        {
                            attackScript.AttackEnemy(currentEnemy, 1f);
                            currentEnemy.enemy.animator.SetTrigger("Attack");
                            nbTurnSA++;
                        }
                        break;
                    }
                    case 1:
                    {
                        //Defense
                        currentEnemy.enemy.defense += 100;
                        currentEnemy.enemy.isInDefense = true;
                        currentEnemy.enemy.animator.SetTrigger("Defense");
                        nbTurnSA++;
                        if(attackScript.player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray") attackScript.player.GetComponentInChildren<Animator>().SetTrigger("!EnemyAtk");
                        break;
                    }
                }
            }
        }
    }  
}
