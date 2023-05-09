using UnityEngine;

public class FighterAction : MonoBehaviour
{
    [SerializeField] public EnemyStats enemy;
    [SerializeField] private AttackScript action;
    private GameObject player;
    [SerializeField] GameObject changeTeamButton;
    [SerializeField] private EnemyManager enemyManager;
    
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject uiSorts;
    private void Start() 
    {
        enemy = enemyManager.currentEnnemi;
    }
    public void SelectAttack(string btn) 
    {
        enemy = enemyManager.currentEnnemi;
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
                changeTeamButton.SetActive(true);


                break;
            default :
                Debug.Log("Fuite");
                //animator.SetTrigger("Fuite");
                break;
        }
    }

}
