using UnityEngine;

public class ChangeEnemySpwanNumber : MonoBehaviour
{
    [SerializeField] int ennemisAGenerer;
    [SerializeField] int enemiesMaxAGenerer;
    TransfereData transfereData;
    private void Awake() {
        transfereData = FindObjectOfType<TransfereData>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Weapon")
        {
            transfereData.enemiesMaxAGenerer = enemiesMaxAGenerer;
            transfereData.ennemisAGenerer = ennemisAGenerer;
        }
    }
}
