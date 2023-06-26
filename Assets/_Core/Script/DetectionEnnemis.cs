using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectionEnnemis : MonoBehaviour
{
    bool hasEnemyHit;
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Enemy")
        {
            if(hasEnemyHit == true)
            {
                TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
                transfereData.enemiesToTransfere.Add(hit.gameObject);
                transfereData.enemyStartFight = true;
                hasEnemyHit = true;
                //if(SceneManager.GetActiveScene().name == "MAP FOREST")
                //{
                    transfereData.ChangeSceneToFight("COMBAT FOREST");
                //} 
            }
        }
    }
}