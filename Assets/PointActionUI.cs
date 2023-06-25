using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointActionUI : MonoBehaviour
{
    TurnManager turnManager;
    [SerializeField] GameObject[] actionPointUI;

    private void Awake() 
    {
        turnManager = FindObjectOfType<TurnManager>();      
    }
    private void Update() 
    {
        if(turnManager.pA == 1)
        {
            actionPointUI[1].SetActive(false);
        }
        if(turnManager.pA == 2)
        {
            actionPointUI[1].SetActive(true);
        }
    }
}
