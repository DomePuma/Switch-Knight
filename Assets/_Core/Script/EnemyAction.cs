using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] private EnemyManager enemy;
    [SerializeField] private AttackScript attackScript;
    [SerializeField] private float attackBooste = 1.2f;
    private int nbTours;

    private EnemyStats ChoseEnemy()
    {
        return enemy.Ennemis[Random.Range(0, 3)];
    }
    public void enemyTurn()
    {
        EnemyStats currentEnemy = ChoseEnemy();
        
        //Attaque chargée
        if(nbTours == 3)
        {
            attackScript.AttackEnemy(currentEnemy, attackBooste);
            Debug.Log("Attaque Lourde" + currentEnemy.enemy.playerName);
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
                    Debug.Log("Attaque Normale" + currentEnemy.enemy.playerName);
                    nbTours++;
                    break;
                }
                case 1:
                {
                    //Defense
                    currentEnemy.enemy.defense += 100;
                    Debug.Log("Defense" + currentEnemy.enemy.playerName);
                    nbTours++;
                    break;
                }
        }
        }
    }  
}
