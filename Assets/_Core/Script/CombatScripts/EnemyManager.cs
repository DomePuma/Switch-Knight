using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    TransfereData enemyData;
    List<GameObject> ennemisObj;
    public List<EnemyStats> Ennemis;
    public EnemyStats currentEnnemi; 
    [SerializeField] GameObject[] prefabEnnemis;
    [SerializeField] GameObject[] emplacementEnnemis;
    [System.NonSerialized] public EnemyStats enemyAttacking;
    int i;
    int j;
    int k;
    int nbEnnemisRestants;
    public float xp;
    [SerializeField] GameObject victoryScreen;


    private void Start() 
    {
        generateEnnemis();   
    }
    private void Update() {
        EndFight();
    }
    private void generateEnnemis()
    {
        enemyData = FindObjectOfType<TransfereData>();
        ennemisObj = enemyData.enemiesToTransfere;
        i = RandomNumberEnemy();
        switch(i)
        {
            case 0:
                break;
            case 1:
                ennemisObj.Add(RandomTypeEnemy());
                break;
            case 2:
                ennemisObj.Add(RandomTypeEnemy());
                ennemisObj.Add(RandomTypeEnemy());
                break;
        }
        for (int j = 0; j < ennemisObj.Count; j++)
        {
            Ennemis.Add(ennemisObj[j].GetComponent<EnemyStats>());
                Ennemis[j].gameObject.transform.position = emplacementEnnemis[j].gameObject.transform.position;
            Ennemis[j].enemy.changeEnemy = this;
            
        }
        nbEnnemisRestants = Ennemis.Count;
        currentEnnemi = Ennemis[0];
        currentEnnemi.selectLight.SetActive(true);
    }
    private int RandomNumberEnemy()
    {
        return Random.Range(0,1);
    }
    private GameObject RandomTypeEnemy()
    {

        return Instantiate(prefabEnnemis[Random.Range(0,3)]);
    }
    
    public void SelectEnnemi()
    {
        k++;
        if( k >= nbEnnemisRestants) k = 0;
        // if(nbEnnemisRestants == 0)
        // {
        //     EnemyDeath();
        // }
        else
        {
            currentEnnemi.selectLight.SetActive(false);
            currentEnnemi = Ennemis[k];
        }
        if(nbEnnemisRestants > 0) currentEnnemi.selectLight.SetActive(true);
    }
    public void EnemyDeath()
    {

        //Destroy(Ennemis[k].gameObject);
        
        nbEnnemisRestants--;
        currentEnnemi.gameObject.SetActive(false);
        SelectEnnemi();
    }
    private void EndFight()
    {
        if(nbEnnemisRestants <= 0)
        {

            victoryScreen.SetActive(true);
        }
    }
}
