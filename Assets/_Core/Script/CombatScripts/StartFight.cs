using UnityEngine;

public class StartFight : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    TransfereData transfereData;
    private void Start()
    {
        transfereData = FindObjectOfType<TransfereData>();
        if(GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>().enemyStartFight)
        {
            turnManager.PassTurn();
            GameObject.FindGameObjectWithTag("UI").gameObject.SetActive(false);
            
        }
    }
}
