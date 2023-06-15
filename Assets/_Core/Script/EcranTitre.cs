using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcranTitre : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<TransfereData>().ChangeScene();
    }
}
