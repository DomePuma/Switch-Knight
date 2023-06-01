using UnityEngine;

public class interactableObject : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public bool interacted = false;
    private void OnTriggerStay(Collider other) 
    {
        Debug.Log("TriggerEnter");
        if(other.gameObject.GetComponent<StarterAssets.ThirdPersonController>()._input.interact == true && interacted == false)
        {
            interacted = true;
            other.gameObject.GetComponent<StarterAssets.ThirdPersonController>().Interact();
            Debug.Log("interact pressed");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        interacted = false;
    }
}