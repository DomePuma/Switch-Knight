using UnityEngine;

public class interactableObject : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public bool interacted = false;
    private void OnTriggerStay(Collider other) 
    {
        Debug.Log("TriggerEnter");
        if(other.gameObject.GetComponent<StarterAssets.ThirdPersonController>()._input.interact && interacted == false)
        {
            interacted = true;
            Debug.Log("interact pressed");
        }
    }
}