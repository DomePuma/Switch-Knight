using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void OnTriggerEnter(Collider other) 
    {
        FindObjectOfType<TransfereData>().ChangeScene(sceneName);
    }
}
