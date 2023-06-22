using UnityEngine;

public class StartFight : MonoBehaviour
{
    TurnManager turnManager;
    TransfereData transfereData;
    [SerializeField] PlayerStats gray;
    
    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        turnManager = FindObjectOfType<TurnManager>();
    }
    private void Start()
    {
        switch(transfereData.currentWeapon)
        {
            case 0 :
                Debug.Log("Ciseau");
                gray.player.typeArmes = TypeArme.Ciseaux;
                gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartCiseau");
                break;
            case 1 :
                Debug.Log("Pioche");
                gray.player.typeArmes = TypeArme.Pioche;
                gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartPioche");
                break;
            case 2 :
                Debug.Log("Marteau");
                gray.player.typeArmes = TypeArme.Marteau;
                gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartMarteau");
                break;
        }
        if(GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>().enemyStartFight == true)
        {
            turnManager.PassTurn();
        }
        else
        {
            turnManager.pA = 2;
            GameObject.FindGameObjectWithTag("UI").gameObject.SetActive(true);
        }
        //gray.player.typeArmes = TypeArme.Ciseaux;
        //gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartCiseau");
    }
}
