using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField] bool physical;
    GameObject currentPlayer;
    [SerializeField] ChosePlayer chosePlayer;

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
        switch(btn)
        {
            case "Attaque":
                currentPlayer.GetComponent<FighterAction>().SelectAttack("Attaque");
                break;
            case "SpecialMove":
                currentPlayer.GetComponent<FighterAction>().SelectAttack("SpecialMove");
                break;
            case "Equipe":
                currentPlayer.GetComponent<FighterAction>().SelectAttack("Equipe");
                break;
            default :
                currentPlayer.GetComponent<FighterAction>().SelectAttack("Fuite");
                break;
        }
    }
}
