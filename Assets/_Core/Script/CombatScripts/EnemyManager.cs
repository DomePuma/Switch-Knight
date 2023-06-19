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
    public int nbEnnemisRestants;
    public float xp;
    [SerializeField] GameObject victoryScreen;


    private void Awake() 
    {
        generateEnnemis();   
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
            Ennemis.Add(ennemisObj[j].GetComponentInChildren<EnemyStats>());
            switch (Ennemis[j].enemy.type)
            {
                case MonsterType.Vegetal:
                    Ennemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y, emplacementEnnemis[j].gameObject.transform.position.z);
                    Ennemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    break;
                case MonsterType.Animal:
                    Ennemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y + 1, emplacementEnnemis[j].gameObject.transform.position.z);
                    Ennemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    break;
                case MonsterType.Mineral:
                    Ennemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y, emplacementEnnemis[j].gameObject.transform.position.z);
                    Ennemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    break;
            }
            Ennemis[j].enemy.changeEnemy = this;
            Ennemis[j].enemy.soundManager = FindObjectOfType<SoundManager>();
            
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
        Debug.Log("SelectEnnemi");
        if(currentEnnemi.enemy.dead == true) Ennemis.Remove(Ennemis[k]);
        if(nbEnnemisRestants != 1)
        {
            k++;
            if( k >= nbEnnemisRestants) k = 0;
            currentEnnemi.selectLight.SetActive(false);
            currentEnnemi = Ennemis[k];

        }
        else
        {
            currentEnnemi = Ennemis[0];
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
            enemyData.DestroyEnnemisList();
        }
    }
}