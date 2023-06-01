using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransfereData : MonoBehaviour
{
    public List<GameObject> enemiesToTransfere;
    public Vector3 playerExploPosition;
    public void ChangeSceneToFight()
    {
        playerExploPosition = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(enemiesToTransfere[0]);
        SceneManager.LoadScene("CombatScene");
    }
    public void ChangeSceneToExplo()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("ExplorationScene");
    }
}