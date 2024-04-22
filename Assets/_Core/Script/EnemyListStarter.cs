using UnityEngine;

public class EnemyListStarter : MonoBehaviour
{
    void Awake()
    {
        TransfereData transfereData = FindObjectOfType<TransfereData>();
        transfereData.enemyIsInDestroyList = false;
        //transfereData.GenerateEnnemisList();
        transfereData.EnemyToDestroy();
    }
}
