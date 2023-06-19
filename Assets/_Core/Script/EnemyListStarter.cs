using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListStarter : MonoBehaviour
{
    void Start()
    {
        Debug.Log(this.name);
        TransfereData transfereData = FindObjectOfType<TransfereData>();
        transfereData.enemyIsInDestroyList = false;
        //transfereData.GenerateEnnemisList();
        transfereData.EnemyToDestroy();
    }
}
