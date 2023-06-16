using UnityEngine;

public class StartFight : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    TransfereData transfereData;
    [SerializeField] PlayerStats gray;
    private void Start()
    {
        transfereData = FindObjectOfType<TransfereData>();
        if(GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>().enemyStartFight == true)
        {
            turnManager.PassTurn();
            GameObject.FindGameObjectWithTag("UI").gameObject.SetActive(false);
            
        }
        else
        {
            turnManager.pA = 2;
            GameObject.FindGameObjectWithTag("UI").gameObject.SetActive(true);
        }
        gray.player.typeArmes = TypeArme.Ciseaux;
        gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartCiseau");
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
    }
}
