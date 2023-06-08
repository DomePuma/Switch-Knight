using UnityEngine;

public class interactableObject : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public bool interacted = false;
    private void OnTriggerStay(Collider other) 
    {
        StarterAssets.ThirdPersonController tps = other.gameObject.GetComponent<StarterAssets.ThirdPersonController>();
        if(tps._input.interact == true)
        {
            interacted = true;
            tps.Interact();
            Debug.Log("interact pressed");
        }
        other.gameObject.GetComponent<StarterAssets.ThirdPersonController>()._input.interact = false;
    }
}