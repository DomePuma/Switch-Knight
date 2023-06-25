using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] GameObject respawnPoint;
    private void OnCollisonEnter(Collision other) 
    {
        
    }
    private void OnCollisionExit(Collision other) 
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        
        if(hit.gameObject.layer == 9)
        {
            this.gameObject.transform.SetParent(hit.gameObject.transform);
            Debug.Log("PlayerPlatform");
        }
        else if(hit.gameObject.layer != 9)
        {
                this.gameObject.transform.parent = null;
        }
        if(hit.gameObject.tag == "OOB")
        {
            CharacterController characterController = this.GetComponent<CharacterController>();
            characterController.enabled = false;
            this.gameObject.transform.position = respawnPoint.transform.position;
        }
    }
}
