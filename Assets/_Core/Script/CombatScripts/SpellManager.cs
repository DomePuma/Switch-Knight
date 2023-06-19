using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject panneauArmes;
    [SerializeField] GameObject healParticle;
    [SerializeField] GameObject atkParticle;
    [SerializeField] GameObject defParticle;
    [SerializeField] PlayerAction UI;
    [SerializeField] float percentHealthHealed;
    SoundManager soundManager;
    PlayerStats[] player;
    TurnManager turnManager;
    public bool isInGuard;
    private void Start() 
    {
        player = FindObjectsOfType<PlayerStats>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void Update() 
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    public void ChangementArmes()
    {
        panneauArmes.SetActive(true);
        //panneauArmes.GetComponent<SwitchWeapon>().SelectButton();
    }
    public void MiseEnGarde()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Mise En Guard");
            UI.QuitUI();
            UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("Garde");
            isInGuard = true;
            turnManager.pA -= 2;
        }
        else
        {
            Debug.Log("Pas assez de PA");
        }
    }
    public void BouclierHumain()
    {
        Debug.Log("Bouclier Humain");
        UI.QuitUI();
        turnManager.hasDefBuff = true;
        turnManager.defBuffCooldown = 3;
        turnManager.pA -= 1;
        UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("BouclierHumain");
        defParticle.SetActive(true);
    }
    public void PositionDefense()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Position de Defense");
            UI.currentPlayer.player.GetComponentInChildren<PlayerStats>().player.isInvincible = true;
            UI.QuitUI();
            turnManager.pA -= 2;
            UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("PositionDeDefense");
            soundManager.SoundFightDefPosition();
        }
        else
        {
            Debug.Log("Pas assez de PA");
        }
        
    }
    public void Soins()
    {
        for(int i = 0; i < player.Length; i++)
        {
            player[i].player.health += player[i].player.maxHealth * (percentHealthHealed/100);
        }
        UI.QuitUI();
        turnManager.pA -= 1;
        UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("Heal");
        soundManager.SoundFightHeal();
        healParticle.SetActive(true);
    }
    public void Amplification()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Amplification");
            turnManager.hasAtkBuff = true;
            turnManager.atkBuffCooldown = 3;
            UI.QuitUI();
            turnManager.pA -= 2;
            UI.currentPlayer.player.GetComponentInChildren<Animator>().SetTrigger("Amplifie");
            soundManager.SoundFightAtkBuff();
            atkParticle.SetActive(true);
        }
        else
        {
            Debug.Log("Pas assez de PA");
        }
    }

}


//Créer un cooldown des sorts + empecher leur utilisations si on a pas assez de PA