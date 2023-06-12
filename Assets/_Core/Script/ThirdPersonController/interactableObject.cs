using UnityEngine;

public class interactableObject : MonoBehaviour
{
    public bool interacted = false;
    [SerializeField] StarterAssets.ThirdPersonController tps;
    private void OnTriggerStay(Collider other) 
    {
        tps = other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>();
        if(tps._input.interact == true)
        {
            interacted = true;
            tps.Interact();
            Debug.Log("interact pressed");
        }
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>()._input.interact = false;
    }
}