using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] int nbSwitchNeed;
    TransfereData transfereData;
    [SerializeField] GameObject[] doorParts;
    [SerializeField] string doorTag;
    void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
    }
    void Update()
    {
        if(transfereData.nbSwitchActive == nbSwitchNeed)
        {
            //for(int i = 0; i< doorParts.Length; i++)
            //{
                doorParts[0].GetComponent<Animator>().SetTrigger("OpenDoor");
            //}
        }
    }
}
