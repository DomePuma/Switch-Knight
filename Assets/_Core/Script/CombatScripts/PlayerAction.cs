using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    ChosePlayer chosePlayer;
    EnemyManager enemyManager;
    AttackScript attackScript;
    UISelect uISelect;
    TurnManager turnManager;
    [SerializeField] GameObject uiSorts;
    [SerializeField] GameObject[] uiEquipe; 
    [SerializeField] GameObject[] Sorts;
    [SerializeField] GameObject[] changeTeamButton;
    
    
    private void Awake() 
    {
        chosePlayer = FindObjectOfType<ChosePlayer>();
        enemyManager = FindObjectOfType<EnemyManager>();
        attackScript = FindObjectOfType<AttackScript>();
        turnManager = FindObjectOfType<TurnManager>();
        uISelect = FindObjectOfType<UISelect>();
    }
    public void Atk()
    {
        chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("Attack");
        attackScript.Attack(enemyManager.currentEnnemi);
        turnManager.pA = 0;
    }
    public void SpecialMove()
    {
        Debug.Log("Attaques Spéciales");
        uiSorts.SetActive(true);
        switch(chosePlayer.currentPlayer)
        {
            case 0:
            {
                Sorts[0].SetActive(true);
                uISelect.SelectSortGray();
                break;
            }
            case 1:
            {
                Sorts[1].SetActive(true);
                uISelect.SelectSortAsthym();
                break;
            }
            case 2:
            {
                Sorts[2].SetActive(true);
                uISelect.SelectSortMaj();
                break;
            }
        }
    }
    public void Epuipe()
    {
        Debug.Log("Equipe");
        switch(chosePlayer.currentPlayer)
        {
            case 0:
            {
                Debug.Log("ChangerGray");
                changeTeamButton[0].SetActive(true);
                uISelect.SelectEquipeGray();
                break;
            }
            case 1:
            {
                Debug.Log("ChangerAsthym");
                changeTeamButton[1].SetActive(true);
                uISelect.SelectEquipeAsthym();
                break;
            }
            case 2:
            {
                Debug.Log("ChangerMaj");
                changeTeamButton[2].SetActive(true);
                uISelect.SelectEquipeMaj();
                break;
            }
        }
    }
    public void Fuite()
    {
        for(int i = 0; i < chosePlayer.players.Count; i++)
        {
            chosePlayer.players[i].gameObject.GetComponentInChildren<Animator>().SetTrigger("Fuite");
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
        switch(chosePlayer.currentPlayer)
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
        uISelect.SelectAtk();
    }
    public void QuitEquipe()
    {
        for(int i = 0; i < uiEquipe.Length; i++)
        {
            uiEquipe[i].SetActive(false);
        }
        uISelect.SelectAtk();
    }
}
