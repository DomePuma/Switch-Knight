using UnityEngine;

public class StartFight : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    TransfereData transfereData;
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
    }
}
