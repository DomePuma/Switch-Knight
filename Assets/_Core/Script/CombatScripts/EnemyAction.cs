using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] private EnemyManager enemy;
    [SerializeField] private AttackScript attackScript;
    [SerializeField] private float attackBooste = 1.2f;
    private int nbTours;

    private EnemyStats ChoseEnemy()
    {
        EnemyStats enemyAtk = enemy.Ennemis[Random.Range(0, enemy.Ennemis.Count)];
        if(enemyAtk.enemy.health <= 0)
        {
            return ChoseEnemy();
        }
        else return enemyAtk;
    }
    public void enemyTurn()
    {
        EnemyStats currentEnemy = ChoseEnemy();
        
        if(currentEnemy.enemy.dead)
        {
            ChoseEnemy();
        }
        else
        {
            //Attaque chargée
            if(nbTours == 3)
            {
                attackScript.AttackEnemy(currentEnemy, attackBooste);
                currentEnemy.enemy.animator.SetTrigger("AttackStrong");
                Debug.Log("Attaque Lourde " + currentEnemy.enemy.playerName);
                nbTours = 0;
            }
            else
            {
                switch(Random.Range(0,2))
                {
                    case 0:
                    {
                        //Attaque
                        attackScript.AttackEnemy(currentEnemy, 1f);
                        currentEnemy.enemy.animator.SetTrigger("Attack");
                        Debug.Log("Attaque Normale " + currentEnemy.enemy.playerName);
                        nbTours++;
                        break;
                    }
                    case 1:
                    {
                        //Defense
                        currentEnemy.enemy.defense += 100;
                        currentEnemy.enemy.animator.SetTrigger("Defense");
                        Debug.Log("Defense " + currentEnemy.enemy.playerName);
                        nbTours++;
                        break;
                    }
                }
            }
        }
    }  
}
