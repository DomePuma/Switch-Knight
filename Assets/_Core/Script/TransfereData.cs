using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransfereData : MonoBehaviour
{
    GameObject[] enemyList;
    List<GameObject> enemyListToDestroy;
    public bool enemyIsInDestroyList;
    
    public List<GameObject> enemiesToTransfere;
    public Vector3 playerExploPosition;
    public bool enemyStartFight;
    public List<int> enemyIDs; 

    private void Start() {
        //enemyID;
    }
    public void ChangeSceneToFight()
    {
        playerExploPosition = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(enemiesToTransfere[0]);
        SceneManager.LoadScene("CombatScene");
    }
    public void ChangeSceneToExplo()
    {
        DontDestroyOnLoad(this.gameObject);
        Destroy(enemiesToTransfere[0]);
        SceneManager.LoadScene("ExplorationScene");
        enemiesToTransfere.Clear();
        
    }
    public void ChangeScene()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("ExplorationScene");
    }
    public void DestroyEnnemisList()
    {
        // for(int i = 0; i < enemyList.Length; i++)
        // {
        //     if(enemyID == enemyList[i].GetComponentInChildren<EnemyStats>().enemy.ID)
        //     {
                
        //     }
        // }
        if(enemyIsInDestroyList == false)
        {
            Debug.Log("EnemyDestroyList");
            enemyIsInDestroyList = true;
            enemyIDs.Add(enemiesToTransfere[0].GetComponent<EnemyStats>().enemy.ID);

        }
            
    }
    public void EnemyToDestroy()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemyList.Length; i++)
        {
            for(int j = 0; j < enemyIDs.Count; j++)
            {
                if(enemyList[i].GetComponentInChildren<EnemyStats>().enemy.ID == enemyIDs[j])
                {
                    Destroy(enemyList[i].gameObject);
                }
            }
        }
        
    }
}