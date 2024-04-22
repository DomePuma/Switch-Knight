using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _attack;
    [SerializeField] private TMP_Text _defense;
    [SerializeField] private Image _icon;
    private PlayerStats _playerStats;
    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        _level.text = "Niveau : " + _playerStats.player.level;
        _health.text = "PV : " + _playerStats.player.health;
        _attack.text = "Attack : " + _playerStats.player.attack;
        _defense.text = "Defense : " + _playerStats.player.defense;
        _icon.sprite = _playerStats.player.icon;
    }
}
