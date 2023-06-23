using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Button");
        if(other.gameObject.tag == "Weapon" && other.GetComponentInParent<StarterAssets.ThirdPersonController>()._currentWeapon == 2)
        {
            this.GetComponent<Animator>().SetTrigger("PushButton");
        }
    }
}
