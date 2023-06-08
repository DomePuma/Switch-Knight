using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] GameObject gray;

    private void Start() 
    {
        gray.GetComponent<CharacterController>().enabled = !gray.GetComponent<CharacterController>().enabled;
        gray.transform.position = GameObject.FindGameObjectWithTag("TransfereData").GetComponentInChildren<TransfereData>().playerExploPosition;
        gray.GetComponent<CharacterController>().enabled = !gray.GetComponent<CharacterController>().enabled;
    }
}
