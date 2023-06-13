using UnityEngine;
public class AtkExplo : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("EnemyHit");
        if(other.tag == "Weapon")
        {
            
            TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
            transfereData.enemiesToTransfere.Add(this.gameObject);
            transfereData.ChangeSceneToFight();
        }     
    }
}
