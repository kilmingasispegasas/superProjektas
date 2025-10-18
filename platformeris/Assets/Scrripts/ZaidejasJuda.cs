using UnityEngine;

public class ZaidejasJuda : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public AudioClip jumpSound;
    
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isGrounded = false;
    
    void Start()
    {
        GameData.MonetuSkIsVisoGautu = 0;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            PlaySound(jumpSound);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    public void Mirk()
    {  
        Time.timeScale = 0f;

        GAMEOVER gameOver = FindObjectOfType<GAMEOVER>();
        if (gameOver != null)
        {
            gameOver.ShowGameOver();
        }
        enabled = false;
    }
    
    public void PlaySound(AudioClip clip)
{
    GameObject tempGO = new GameObject("TempAudio");
    AudioSource aSource = tempGO.AddComponent<AudioSource>(); 
    aSource.clip = clip;
    aSource.Play();
    Destroy(tempGO, clip.length);
}

}