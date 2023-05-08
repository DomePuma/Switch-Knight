using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField] bool physical;
    public GameObject currentPlayer;
    [SerializeField] public ChosePlayer chosePlayer;

    private void Update() 
    {
        currentPlayer = chosePlayer.player;
    }

    private void Start() 
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
    }
    private void AttachCallback(string btn)
    {
        Debug.Log(btn);
        switch(btn)
        {
            case "Attaque":
                currentPlayer.GetComponentInChildren<FighterAction>().SelectAttack("Attaque");
                break;
            case "SpecialMove":
                currentPlayer.GetComponentInChildren<FighterAction>().SelectAttack("SpecialMove");
                break;
            case "Equipe":
                currentPlayer.GetComponentInChildren<FighterAction>().SelectAttack("Equipe");
                break;
            default :
                currentPlayer.GetComponentInChildren<FighterAction>().SelectAttack("Fuite");
                break;
        }
    }
}
