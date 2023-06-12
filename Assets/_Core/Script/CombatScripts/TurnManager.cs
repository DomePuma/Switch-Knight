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
    }
}
