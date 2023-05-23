using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransfereData : MonoBehaviour
{
    public List<GameObject> enemiesToTransfere;
    public void ChangeScene()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(enemiesToTransfere[0]);
        SceneManager.LoadScene("CombatScene");
    } 
}
