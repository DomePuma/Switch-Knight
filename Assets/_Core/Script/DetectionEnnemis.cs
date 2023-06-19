using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectionEnnemis : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Enemy")
        {
            TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
            Debug.Log(hit);
            transfereData.enemiesToTransfere.Add(hit.gameObject);
            transfereData.enemyStartFight = true;
            //if(SceneManager.GetActiveScene().name == "MAP FOREST")
            //{
                transfereData.ChangeSceneToFight("COMBAT FOREST");
            //}   
        }
    }
}