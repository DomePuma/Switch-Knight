using UnityEngine;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;
    
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject attaquePrefab;

    [SerializeField] private GameObject guardPrefab;
    [SerializeField] private GameObject switchPrefab;
    [SerializeField] private Sprite faceIcon;
    
    private GameObject currentAttack;
    private GameObject attaque;
    private GameObject SpecialMove;
    private GameObject switchWeapon;

    public void SelectAttack(string btn) 
    {
        GameObject victim = player;
        if(tag == "Player")
        {
            victim = enemy;
        }
        switch(btn)
        {
            case "Attaque":
                Debug.Log("Attaque");
                animator.SetTrigger("Attaque");
                break;
            case "SpecialMove":
                Debug.Log("Attaques Spéciales");
                animator.SetTrigger("Garde");
                break;
            case "Equipe":
                Debug.Log("Equipe");
                break;
            default :
                Debug.Log("Fuite");
                animator.SetTrigger("Fuite");
                break;
        }
    }

}
