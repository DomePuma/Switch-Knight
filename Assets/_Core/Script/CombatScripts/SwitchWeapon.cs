using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] PlayerStats player;
    [SerializeField] TurnManager turnManager;
    [SerializeField] Button ciseauBtn;
    [SerializeField] Button piocheBtn;
    [SerializeField] Button marteauBtn;
    [SerializeField] PlayerAction UI;

    private void Update() 
    {
        if(player.player.typeArmes == "Ciseaux") ciseauBtn.interactable = false; else ciseauBtn.interactable = true;
        if(player.player.typeArmes == "Pioche") piocheBtn.interactable = false; else piocheBtn.interactable = true;
        if(player.player.typeArmes == "Marteau") marteauBtn.interactable = false; else marteauBtn.interactable = true;
    }
    public void choixCiseaux()
    {
        player.player.SwitchArme(0);
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
    public void choixPioche()
    {
        player.player.SwitchArme(1);
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
    public void choixMarteau()
    {
        player.player.SwitchArme(2);
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
}
