using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] public ChosePlayer currentPlayer;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] AttackScript action;
    [SerializeField] TurnManager turnManager;
    [SerializeField] GameObject uiSorts;
    [SerializeField] GameObject[] Sorts;
    [SerializeField] GameObject[] changeTeamButton;
    
    public void Atk()
    {
        Debug.Log("Attaque");
        action.Attack(enemyManager.currentEnnemi);
        currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("Attaque");
        turnManager.pA = 0;
    }
    public void SpecialMove()
    {
        Debug.Log("Attaques Spéciales");
        uiSorts.SetActive(true);
        switch(currentPlayer.currentPlayer)
        {
            case 0:
            {
                Sorts[0].SetActive(true);
                break;
            }
            case 1:
            {
                Sorts[1].SetActive(true);
                break;
            }
            case 2:
            {
                Sorts[2].SetActive(true);
                break;
            }
        }
    }
    public void Epuipe()
    {
        Debug.Log("Equipe");
        switch(currentPlayer.currentPlayer)
        {
            case 0:
            {
                Debug.Log("ChangerGray");
                changeTeamButton[0].SetActive(true);
                break;
            }
            case 1:
            {
                Debug.Log("ChangerAsthym");
                changeTeamButton[1].SetActive(true);
                break;
            }
            case 2:
            {
                Debug.Log("ChangerMaj");
                changeTeamButton[2].SetActive(true);
                break;
            }
        }
    }
    public void Fuite()
    {
        for(int i = 0; i < currentPlayer.players.Length; i++)
        {
            currentPlayer.players[i].gameObject.GetComponentInChildren<Animator>().SetTrigger("Fuite");
        }
        StartCoroutine(FuiteTimer());
        
    }
    private IEnumerator FuiteTimer()
    {
        yield return new WaitForSecondsRealtime(3);
        FindObjectOfType<TransfereData>().Fuite();
    }
    public void QuitUI()
    {
        switch(currentPlayer.currentPlayer)
        {
            case 0:
            {
                Sorts[0].SetActive(false);
                break;
            }
            case 1:
            {
                Sorts[1].SetActive(false);
                break;
            }
            case 2:
            {
                Sorts[2].SetActive(false);
                break;
            }
        }
        uiSorts.SetActive(false);
    }
}
