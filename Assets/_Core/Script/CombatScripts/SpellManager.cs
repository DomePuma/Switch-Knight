using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject panneauArmes;
    [SerializeField] PlayerAction UI;
    [SerializeField] float percentHealthHealed;
    PlayerStats[] ListPlayer;
    TurnManager turnManager;
    public bool isInGuard;
    private void Start() 
    {
        ListPlayer = FindObjectsOfType<PlayerStats>();  
        turnManager = FindObjectOfType<TurnManager>();      
    }

    public void ChangementArmes()
    {
        panneauArmes.SetActive(true);
    }
    public void MiseEnGarde()
    {
        Debug.Log("Mise En Guard");
        UI.QuitUI();
        UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("Garde");
        isInGuard = true;
        turnManager.pA -= 2;
    }
    public void BouclierHumain()
    {
        Debug.Log("Bouclier Humain");
        UI.QuitUI();
        turnManager.pA -= 1;
        UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("BouclierHumain");
    }
    public void PositionDefense()
    {
        Debug.Log("Position de Defense");
        UI.QuitUI();
        turnManager.pA -= 2;
        UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("PositionDeDefense");
    }
    public void Soins()
    {
        for(int i = 0; i < ListPlayer.Length; i++)
        {
            ListPlayer[i].player.health += ListPlayer[i].player.maxHealth * (percentHealthHealed/100);
        }
        UI.QuitUI();
        turnManager.pA -= 1;
        UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("Heal");
    }
    public void Amplification()
    {
        Debug.Log("Amplification");
        UI.QuitUI();
        turnManager.pA -= 2;
        UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("Amplifie");
    }

}
