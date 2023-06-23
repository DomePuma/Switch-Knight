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
    public int currentWeapon;
    public void ChangeSceneToFight(string sceneName)
    {
        playerExploPosition = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(enemiesToTransfere[0]);
        currentWeapon = FindObjectOfType<StarterAssets.ThirdPersonController>()._currentWeapon;
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeSceneToExplo()
    {
        DontDestroyOnLoad(this.gameObject);
        Destroy(enemiesToTransfere[0]);
        SceneManager.LoadScene("MAP FOREST");
        enemiesToTransfere.Clear();
        
    }
    public void ChangeScene(string sceneName)
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(sceneName);
        enemyIDs.Clear();
    }
    public void Fuite()
    {
        DontDestroyOnLoad(this.gameObject);
        Destroy(enemiesToTransfere[0]);
        SceneManager.LoadScene("MAP FOREST");
        enemiesToTransfere.Clear();
    }
    public void DestroyEnnemisList()
    {
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