using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject uiPlayer;
    [SerializeField] EnemyAction enemyAction;
    public int pA;
    private bool hasEnemyAtk = false;
    
    private void Update() {
        if(pA <= 0 && hasEnemyAtk == false)
        {
            uiPlayer.SetActive(false);
            pA = 2;
            passTurn();
            
        }
    }
    public void passTurn()
    {
        enemyAction.enemyTurn();
        hasEnemyAtk = true;
    }
    public void endTurnEnemy()
    {
        uiPlayer.SetActive(true);
        hasEnemyAtk = false;
    }
}
