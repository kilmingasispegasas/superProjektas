using UnityEngine;

public static class GameData
{
    public static int MonetuSkIsVisoGautu = 0;
}

public class Pinigai : MonoBehaviour
{
    public AudioClip coinSound;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.MonetuSkIsVisoGautu++;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
        }
    }
}