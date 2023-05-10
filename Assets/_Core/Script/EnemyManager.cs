using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyStats[] Ennemis;
    public EnemyStats currentEnnemi;
    [SerializeField] int maxEnnemis; 
    [System.NonSerialized] public EnemyStats enemyAttacking;
    int i;

    private void Start() 
    {
        Ennemis = FindObjectsOfType<EnemyStats>();
        currentEnnemi = Ennemis[0];
        currentEnnemi.selectLight.SetActive(true);
    }
    public void SelectEnnemi()
    {
        i++;
        if( i >= maxEnnemis) i = 0;
        currentEnnemi.selectLight.SetActive(false);
        currentEnnemi = Ennemis[i];
        currentEnnemi.selectLight.SetActive(true);
    }
}
