using UnityEngine;

public class blogiblokai : MonoBehaviour
{
    public AudioClip hurtSound;
    void Start()
    {
        GameData.MonetuSkIsVisoGautu = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            other.GetComponent<ZaidejasJuda>().Mirk();       }
    }
}