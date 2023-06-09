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
        if(player.player.typeArmes == TypeArme.Ciseaux) ciseauBtn.interactable = false; else ciseauBtn.interactable = true;
        if(player.player.typeArmes == TypeArme.Pioche) piocheBtn.interactable = false; else piocheBtn.interactable = true;
        if(player.player.typeArmes == TypeArme.Marteau) marteauBtn.interactable = false; else marteauBtn.interactable = true;
    }
    public void choixCiseaux()
    {
        player.player.typeArmes = TypeArme.Ciseaux;
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
    public void choixPioche()
    {
        player.player.typeArmes = TypeArme.Pioche;
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
    public void choixMarteau()
    {
        player.player.typeArmes = TypeArme.Marteau;
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
}
