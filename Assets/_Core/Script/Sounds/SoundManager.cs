using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [Header("Weapons")]
    [SerializeField] AudioClip fightSword;
    [SerializeField] AudioClip fightPickaxe;
    [SerializeField] AudioClip fightHammer;
    [SerializeField] AudioClip fightMajAttack;

    [Header("Buffs")]
    [SerializeField] AudioClip fightAtkBuff;
    [SerializeField] AudioClip fightDefPosition;
    
    [Header("Spells")]
    [SerializeField] AudioClip fightHeal;
    [SerializeField] AudioClip fightSwitch;

    [Header("Other")]
    [SerializeField] AudioClip fightHurt;
    [SerializeField] AudioSource audioSource;

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
        audioSource.clip = fightSword;
        audioSource.Play();
    }
    public void SoundFightPickaxe()
    {
        audioSource.clip = fightPickaxe;
        audioSource.Play();
    }
    public void SoundFightHammer()
    {
        audioSource.clip = fightHammer;
        audioSource.Play();
    }
    public void SoundFightAllyHurt()
    {
        audioSource.clip = fightHurt;
        audioSource.Play();
    }
    public void SoundFightEnemyHurt()
    {
        audioSource.clip = fightHurt;
        audioSource.Play();
    }
    public void SoundFightAtkBuff()
    {
        audioSource.clip = fightAtkBuff;
        audioSource.Play();
    }
    public void SoundFightDefPosition()
    {
        audioSource.clip = fightDefPosition;
        audioSource.Play();
    }
    public void SoundFightHeal()
    {
        audioSource.clip = fightHeal;
        audioSource.Play();
    }
    public void SoundFightMajAttack()
    {
        audioSource.clip = fightMajAttack;
        audioSource.Play();
    }
    public void SoundFightSwitch()
    {
        audioSource.clip = fightSwitch;
        audioSource.Play();
    }
}
