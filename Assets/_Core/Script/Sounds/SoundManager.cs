using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [Header("Weapons")]
    [SerializeField] AudioSource fightSword;
    [SerializeField] AudioSource fightPickaxe;
    [SerializeField] AudioSource fightHammer;
    [SerializeField] AudioSource fightMajAttack;

    [Header("Buffs")]
    [SerializeField] AudioSource fightAtkBuff;
    [SerializeField] AudioSource fightDefPosition;
    
    [Header("Spells")]
    [SerializeField] AudioSource fightHeal;
    [SerializeField] AudioSource fightSwitch;

    [Header("Other")]
    [SerializeField] AudioSource fightHurt;

    EnemyStats[] ennemis;
    PlayerStats[] players;
    
    private void Start()
    {
        enemyConfigSound();
        playerConfigSound();
    }
    private void enemyConfigSound()
    {
        ennemis = FindObjectsOfType<EnemyStats>();
        for(int i = 0; i < ennemis.Length; i++)
        {
            ennemis[i].enemy.soundManager = this;
        }
    }
    private void playerConfigSound()
    {
        players = FindObjectsOfType<PlayerStats>();
        for(int i = 0; i < players.Length; i++)
        {
            players[i].player.soundManager = this;
        }

    }
    public void SoundFightSword()
    {
        fightSword.Play();
    }
    public void SoundFightPickaxe()
    {
        fightPickaxe.Play();
    }
    public void SoundFightHammer()
    {
        fightHammer.Play();
    }
    public void SoundFightAllyHurt()
    {
        fightHurt.Play();
    }
    public void SoundFightEnemyHurt()
    {
        fightHurt.Play();
    }
    public void SoundFightAtkBuff()
    {
        fightAtkBuff.Play();
    }
    public void SoundFightDefPosition()
    {
        fightDefPosition.Play();
    }
    public void SoundFightHeal()
    {
        fightHeal.Play();
    }
    public void SoundFightMajAttack()
    {
        fightMajAttack.Play();
    }
    public void SoundFightSwitch()
    {
        fightSwitch.Play();
    }
}
