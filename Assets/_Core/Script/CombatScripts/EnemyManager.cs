using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyStats[] Ennemis;
    public EnemyStats currentEnnemi;
    [SerializeField] int maxEnnemis; 
    [System.NonSerialized] public EnemyStats enemyAttacking;
    int i;
    int nbEnnemisRestants;
    [SerializeField] GameObject victoryScreen;

    private void Start() 
    {
        Ennemis = FindObjectsOfType<EnemyStats>();
        nbEnnemisRestants = Ennemis.Length;
        currentEnnemi = Ennemis[0];
        currentEnnemi.selectLight.gameObject.SetActive(true);
    }
    public void SelectEnnemi()
    {
        i++;
        if( i >= maxEnnemis) i = 0;
        currentEnnemi.selectLight.gameObject.SetActive(true);
        currentEnnemi = Ennemis[i];
        if(nbEnnemisRestants > 0) currentEnnemi.selectLight.gameObject.SetActive(true);
    }
    public void EnemyDeath()
    {
        if(nbEnnemisRestants <= 0)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            nbEnnemisRestants--;
            SelectEnnemi();
        }
    }
}
