using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject panneauArmes;
    [SerializeField] GameObject healParticle;
    [SerializeField] GameObject atkParticle;
    [SerializeField] GameObject defParticle;
    [SerializeField] float percentHealthHealed;
    [SerializeField] private GameObject _ui;
    PlayerAction playerAction;
    SoundManager soundManager;
    PlayerStats[] player;
    TurnManager turnManager;
    ChosePlayer chosePlayer;
    public bool isInGuard;
    
    private void Start() 
    {
        player = FindObjectsOfType<PlayerStats>();
        soundManager = FindObjectOfType<SoundManager>();
        turnManager = FindObjectOfType<TurnManager>();
        playerAction = FindObjectOfType<PlayerAction>();
        chosePlayer = FindObjectOfType<ChosePlayer>();
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
            playerAction.QuitUI();
            chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("Garde");
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
        playerAction.QuitUI();
        turnManager.hasDefBuff = true;
        turnManager.defBuffCooldown = 3;
        turnManager.pA -= 1;
        chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("BouclierHumain");
        defParticle.SetActive(true);
        _ui.SetActive(false);
    }
    public void PositionDefense()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Position de Defense");
            chosePlayer.player.GetComponentInChildren<PlayerStats>().player.isInvincible = true;
            playerAction.QuitUI();
            turnManager.pA -= 2;
            chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("PositionDeDefense");
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
        playerAction.QuitUI();
        turnManager.pA -= 1;
        chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("Heal");
        soundManager.SoundFightHeal();
        healParticle.SetActive(true);
        _ui.SetActive(false);
    }
    public void Amplification()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Amplification");
            turnManager.hasAtkBuff = true;
            turnManager.atkBuffCooldown = 3;
            playerAction.QuitUI();
            turnManager.pA -= 2;
            chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("Amplifie");
            soundManager.SoundFightAtkBuff();
            atkParticle.SetActive(true);
        }
        else
        {
            Debug.Log("Pas assez de PA");
        }
    }

    private void OnEnable()
    {
        SpellUI.ShowUIAction += ShowUIAction;
    }

    private void ShowUIAction()
    {
        _ui.SetActive(true);
    }

    private void OnDisable()
    {
        SpellUI.ShowUIAction -= ShowUIAction;
    }
}