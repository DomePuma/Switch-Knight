using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] Button ciseauBtn;
    [SerializeField] Button piocheBtn;
    [SerializeField] Button marteauBtn;
    [SerializeField] private GameObject _ui;
    PlayerStats player;
    ChosePlayer chosePlayer;
    TurnManager turnManager;
    PlayerAction playerAction;
    UISelect uISelect;
    
    private void Awake() 
    {
        chosePlayer = FindObjectOfType<ChosePlayer>();
        turnManager = FindObjectOfType<TurnManager>();
        playerAction = FindObjectOfType<PlayerAction>();
        uISelect = FindObjectOfType<UISelect>();
    }
    private void OnEnable() 
    {
        if(player != null)
        {
            if(player.player.typeArmes == TypeArme.Ciseaux) {ciseauBtn.interactable = false; uISelect.SelectGrayPickaxe();} else ciseauBtn.interactable = true;
            if(player.player.typeArmes == TypeArme.Pioche) {piocheBtn.interactable = false; uISelect.SelectGraySword();}else piocheBtn.interactable = true;
            if(player.player.typeArmes == TypeArme.Marteau) {marteauBtn.interactable = false; uISelect.SelectGraySword();} else marteauBtn.interactable = true;
        }
        else
        {
            SelectFirstTime();
        }
    }
    private void SelectFirstTime()
    {
        player = chosePlayer.players[0].GetComponentInChildren<PlayerStats>();
        if(player.player.typeArmes == TypeArme.Ciseaux) {ciseauBtn.interactable = false; uISelect.SelectGrayPickaxe();} else ciseauBtn.interactable = true;
        if(player.player.typeArmes == TypeArme.Pioche) {piocheBtn.interactable = false; uISelect.SelectGraySword();}else piocheBtn.interactable = true;
        if(player.player.typeArmes == TypeArme.Marteau) {marteauBtn.interactable = false; uISelect.SelectGraySword();} else marteauBtn.interactable = true;
    }
    public void ChoixCiseaux()
    {
        _ui.SetActive(false);
        player.player.typeArmes = TypeArme.Ciseaux;
        player.gameObject.GetComponent<Animator>().SetTrigger("ChangeCiseau");
        turnManager.pA--;
        playerAction.QuitUI();
        //this.gameObject.SetActive(false);
    }
    public void ChoixPioche()
    {
        _ui.SetActive(false);
        player.player.typeArmes = TypeArme.Pioche;
        player.gameObject.GetComponent<Animator>().SetTrigger("ChangePioche");
        turnManager.pA--;
        playerAction.QuitUI();
        //this.gameObject.SetActive(false);
    }
    public void ChoixMarteau()
    {
        _ui.SetActive(false);
        player.player.typeArmes = TypeArme.Marteau;
        player.gameObject.GetComponent<Animator>().SetTrigger("ChangeMarteau");
        turnManager.pA--;
        playerAction.QuitUI();
        //this.gameObject.SetActive(false);
    }
}
