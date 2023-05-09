using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] ChosePlayer player;
    [SerializeField] Image currentIcon;
    [SerializeField] TMP_Text currentName;

    private void Update() {
        currentIcon.sprite = player.player.GetComponentInChildren<PlayerStats>().player.icon;
        currentName.text = player.player.GetComponentInChildren<PlayerStats>().player.playerName;
    }
}
