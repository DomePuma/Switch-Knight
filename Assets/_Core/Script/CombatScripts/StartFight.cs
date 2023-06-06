using UnityEngine;

public class StartFight : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>().enemyStartFight)
        {
            turnManager.PassTurn();
            GameObject.FindGameObjectWithTag("UI").gameObject.SetActive(false);
        }
    }
}
