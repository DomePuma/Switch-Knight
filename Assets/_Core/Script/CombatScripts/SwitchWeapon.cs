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
    [SerializeField] UISelect uISelect;
    private void OnEnable() 
    {
        if(player.player.typeArmes == TypeArme.Ciseaux) {ciseauBtn.interactable = false; uISelect.SelectGrayPickaxe();} else ciseauBtn.interactable = true;
        if(player.player.typeArmes == TypeArme.Pioche) {piocheBtn.interactable = false; uISelect.SelectGraySword();}else piocheBtn.interactable = true;
        if(player.player.typeArmes == TypeArme.Marteau) {marteauBtn.interactable = false; uISelect.SelectGraySword();} else marteauBtn.interactable = true;
    }
    public void ChoixCiseaux()
    {
        player.player.typeArmes = TypeArme.Ciseaux;
        player.gameObject.GetComponent<Animator>().SetTrigger("ChangeCiseau");
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
    public void ChoixPioche()
    {
        player.player.typeArmes = TypeArme.Pioche;
        player.gameObject.GetComponent<Animator>().SetTrigger("ChangePioche");
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
    public void ChoixMarteau()
    {
        player.player.typeArmes = TypeArme.Marteau;
        player.gameObject.GetComponent<Animator>().SetTrigger("ChangeMarteau");
        turnManager.pA--;
        UI.QuitUI();
        this.gameObject.SetActive(false);
    }
}
