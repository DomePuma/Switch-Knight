using UnityEngine;

public class AudioStartOST : MonoBehaviour
{
    [SerializeField] AudioSource ost;

    private void Start()
    {
        ost.Play();
    }

}
