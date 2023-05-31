using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] ChosePlayer player;
    [SerializeField] Image currentIcon;
    [SerializeField] TMP_Text currentName;
    [SerializeField] Sprite deadPlaceHolder;

    private void Update() {
        if(player.player == player.dead)
        {
           currentIcon.sprite = deadPlaceHolder;
           currentName.text = "Dead";
        }
        else
        {
            currentIcon.sprite = player.player.GetComponentInChildren<PlayerStats>().player.icon;
            currentName.text = player.player.GetComponentInChildren<PlayerStats>().player.playerName;
        }    
    }
}
