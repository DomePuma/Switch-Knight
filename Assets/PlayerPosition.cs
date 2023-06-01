using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] GameObject gray;

    private void Start() 
    {
        //gray.transform.position = GameObject.FindGameObjectWithTag("TransfereData").GetComponentInChildren<TransfereData>().playerExploPosition;
    }
}
