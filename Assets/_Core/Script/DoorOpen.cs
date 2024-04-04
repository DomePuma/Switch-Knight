using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] int nbSwitchNeed;
    TransfereData transfereData;
    [SerializeField] GameObject[] doorParts;
    void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
    }
    void Update()
    {
        if(transfereData.nbSwitchActive == nbSwitchNeed)
        {
            for(int i = 0; i< doorParts.Length; i++)
            {
                doorParts[i].GetComponent<Animator>().SetTrigger("OpenDoor");
            }
        }
    }
}
