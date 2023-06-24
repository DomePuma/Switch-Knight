using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    bool hasBeenCut;
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Leaves");
        if(other.gameObject.tag == "Weapon" && 
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>()._currentWeapon == 0 &&
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isAttacking &&
        !hasBeenCut)
        {
            this.GetComponent<Animator>().SetTrigger("CutLeaves");
            hasBeenCut = true;
        }
    }
}
