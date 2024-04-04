using UnityEngine;

public class Leaves : MonoBehaviour
{
    bool hasBeenCut;
    private void OnCollisionEnter(Collision other) 
    {
        
        if(other.gameObject.tag == "Weapon" && 
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>()._currentWeapon == 0 &&
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isAttacking &&
        !hasBeenCut)
        {
            Debug.Log("Leaves");
            this.GetComponent<Animator>().SetTrigger("CutLeaves");
            hasBeenCut = true;
        }
    }
}
