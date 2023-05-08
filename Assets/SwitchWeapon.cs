using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] PlayerStats player;

    public void choixCiseaux()
    {
        player.player.SwitchArme(0);
    }
    public void choixPioche()
    {
        player.player.SwitchArme(1);
    }
    public void choixMarteau()
    {
        player.player.SwitchArme(2);
    }
}
