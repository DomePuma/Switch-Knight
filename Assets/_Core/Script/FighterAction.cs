using UnityEngine;

public class FighterAction : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    [SerializeField] private AttackScript action;
    private GameObject player;
    
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite faceIcon;
    [SerializeField] private GameObject uiSorts;
    public void SelectAttack(string btn) 
    {
        // GameObject victim = player;
        // if(tag == "Player")
        // {
        //     victim = enemy;
        // }
        switch(btn)
        {
            case "Attaque":
                Debug.Log("Attaque");
                action.Attack(enemy);
                animator.SetTrigger("Attaque");
                break;
            case "SpecialMove":
                Debug.Log("Attaques Spéciales");
                uiSorts.SetActive(true);
                animator.SetTrigger("Garde");
                break;
            case "Equipe":
                Debug.Log("Equipe");
                break;
            default :
                Debug.Log("Fuite");
                action.LevelUP(1);
                //animator.SetTrigger("Fuite");
                break;
        }
    }

}
