using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransfereDataToFight : MonoBehaviour
{
    public List<GameObject> enemiesToTransfere;
    public Vector3 playerExploPosition;
    public void ChangeScene()
    {
        playerExploPosition = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(enemiesToTransfere[0]);
        SceneManager.LoadScene("CombatScene");
    } 
}
