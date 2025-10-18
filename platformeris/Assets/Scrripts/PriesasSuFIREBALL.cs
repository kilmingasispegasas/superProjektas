using UnityEngine;

public class PriesasSuFIREBALL : MonoBehaviour
{
    public Sprite fireballSprite;
    public float shootDistance = 10f;
    public float shootCooldown = 2f;

    private Transform player;
    private float lastShootTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;
        
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < shootDistance && Time.time > lastShootTime + shootCooldown)
        {
            ShootFireball();
            lastShootTime = Time.time;
        }
    }

    void ShootFireball()
    {
        GameObject fireball = new GameObject("Fireball");
        SpriteRenderer sr = fireball.AddComponent<SpriteRenderer>();
        sr.sprite = fireballSprite;
        fireball.transform.position = transform.position;
        CircleCollider2D collider = fireball.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        Fireball fb = fireball.AddComponent<Fireball>();
        Vector2 direction = (player.position - transform.position).normalized;
        fb.SetDirection(direction);
    }
}

public class Fireball : MonoBehaviour
{
    public float speed = 4f;
    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            ZaidejasJuda playerScript = other.GetComponent<ZaidejasJuda>();
            if (playerScript != null)
            {
                playerScript.Mirk();
            }
            Destroy(gameObject);
        }
    }
}