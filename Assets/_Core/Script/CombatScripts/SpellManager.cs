using UnityEngine;
using UnityEngine.Serialization;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject panneauArmes;
    [SerializeField] GameObject healParticle;
    [SerializeField] GameObject atkParticle;
    [SerializeField] GameObject defParticle;
    [SerializeField] float percentHealthHealed;
    [FormerlySerializedAs("_ui")] [SerializeField] private GameObject _canvasUI;
    [FormerlySerializedAs("_spellUIGray")] [SerializeField] private GameObject _spellUIGrey;
    [SerializeField] private GameObject _spellUIAsthym;
    [SerializeField] private GameObject _spellUIMaj;
    PlayerAction playerAction;
    SoundManager soundManager;
    PlayerStats[] player;
    TurnManager turnManager;
    ChosePlayer chosePlayer;
    public bool isInGuard;

    private bool _asthymInGuard = false;
    
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
        _canvasUI.SetActive(false);
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
            _asthymInGuard = true;
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
        _canvasUI.SetActive(false);
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
    
    public void HideUIAsthymPA2()
    {
        if (turnManager.pA < 2) return;
        _spellUIAsthym.SetActive(false);
    }
    
    public void HideUIGreyPA2()
    {
        if (turnManager.pA < 2) return;
        _spellUIGrey.SetActive(false);
    }
    
    public void HideUIMajPA2()
    {
        if (turnManager.pA < 2) return;
        _spellUIMaj.SetActive(false);
    }
    
    private void OnEnable()
    {
        SpellUI.ShowUIAction += ShowUIAction;
        NotAtk.EnemyNotAtkAction += EnemyNotAtkAction;
        Atk.EnemyAtkAction += EnemyAtkAction;
    }

    private void EnemyNotAtkAction()
    {
        if (_asthymInGuard)
        {
            Debug.Log("EnemyNotAtkAction");
            chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("!EnemyAtk");
            _asthymInGuard = false;
        }
    }

    private void ShowUIAction()
    {
        _canvasUI.SetActive(true);
    }

    private void OnDisable()
    {
        SpellUI.ShowUIAction -= ShowUIAction;
        NotAtk.EnemyNotAtkAction -= EnemyNotAtkAction;
        Atk.EnemyAtkAction -= EnemyAtkAction;
    }

    private void EnemyAtkAction()
    {
        chosePlayer.player.GetComponentInChildren<Animator>().SetTrigger("EnnemiAtk");
    }
}