using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcranTitre : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void Start()
    {
        FindObjectOfType<TransfereData>().ChangeScene(sceneName);
    }
}
