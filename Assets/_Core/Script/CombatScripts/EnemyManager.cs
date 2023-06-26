using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    TransfereData transfereData;
    List<GameObject> enemisObj;
    public List<EnemyStats> enemis;
    public EnemyStats currentEnnemi;
    public Vector3 currentEnnemiAtkPosition;
    [SerializeField] GameObject[] prefabEnnemis;
    public GameObject[] emplacementEnnemis;
    [SerializeField] GameObject[] emplacementAtkEnnemis;
    int nbEnemies;
    int enemyOrder;
    public float nbEnnemisRestants;
    public float xp;
    [SerializeField] GameObject victoryScreen;


    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        generateEnnemis();   
    }
    private void generateEnnemis()
    {
        enemisObj = transfereData.enemiesToTransfere;
        nbEnemies = RandomNumberEnemy();
        switch(nbEnemies)
        {
            case 0:
                break;
            case 1:
                enemisObj.Add(RandomTypeEnemy());
                break;
            case 2:
                enemisObj.Add(RandomTypeEnemy());
                enemisObj.Add(RandomTypeEnemy());
                break;
        }
        for (int j = 0; j < enemisObj.Count; j++)
        {
            enemis.Add(enemisObj[j].GetComponentInChildren<EnemyStats>());
            switch (enemis[j].enemy.type)
            {
                case MonsterType.Vegetal:
                    enemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y, emplacementEnnemis[j].gameObject.transform.position.z);
                    enemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    break;
                case MonsterType.Animal:
                    enemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y + 1, emplacementEnnemis[j].gameObject.transform.position.z);
                    enemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    break;
                case MonsterType.Mineral:
                    enemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y, emplacementEnnemis[j].gameObject.transform.position.z);
                    enemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    break;
            }
            enemis[j].enemy.changeEnemy = this;
            enemis[j].enemy.soundManager = FindObjectOfType<SoundManager>();
            enemis[j].gameObject.GetComponent<Follower>().enabled = false;
            enemis[j].gameObject.GetComponentInChildren<Animator>().runtimeAnimatorController = enemis[j].enemy.animatorFight;
        }
        nbEnnemisRestants = enemis.Count;
        currentEnnemi = enemis[0];
        currentEnnemiAtkPosition = emplacementAtkEnnemis[0].transform.position;
        currentEnnemi.selectLight.SetActive(true);
    }
    private int RandomNumberEnemy()
    {
        return Random.Range(0,3);
    }
    private GameObject RandomTypeEnemy()
    {
        return Instantiate(prefabEnnemis[Random.Range(0,3)]);
    }
    public void SelectEnnemi()
    {
        Debug.Log("SelectEnnemi");
        if(currentEnnemi.enemy.dead == true) enemis.Remove(enemis[enemyOrder]);
        if(nbEnnemisRestants != 1)
        {
            enemyOrder++;
            if( enemyOrder >= nbEnnemisRestants) enemyOrder = 0;
            currentEnnemi.selectLight.SetActive(false);
            currentEnnemi = enemis[enemyOrder];
            currentEnnemiAtkPosition = emplacementAtkEnnemis[enemyOrder].transform.position;
        }
        else
        {
            currentEnnemi = enemis[0];
        }
        if(nbEnnemisRestants > 0) currentEnnemi.selectLight.SetActive(true);
    }
    public void EnemyDeath()
    {
        nbEnnemisRestants--;
        currentEnnemi.gameObject.GetComponentInChildren<Animator>().SetBool("Death", true);
        currentEnnemi.gameObject.SetActive(false);
        Debug.Log("EnemyDead");
        SelectEnnemi();
        
    }
    public void EndFight()
    {
        if(nbEnnemisRestants <= 0)
        {
            victoryScreen.SetActive(true);
            transfereData.DestroyEnnemisList();
        }
    }
}