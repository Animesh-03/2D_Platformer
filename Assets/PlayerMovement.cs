using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb; 
   public Transform groundCheck;
   public LayerMask groundLayer;
   public KeyCode jumpButton;
   public float forceMultiplier;
   public float jumpMultiplier;
   public AudioClip jumpStartAudio;
   public AudioSource audioSource;
   private float inputX;
   private float inputY;
   [SerializeField]
   private bool canJump;
   private float jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical"); 

        canJump = (Physics2D.OverlapCircle(groundCheck.position,0.1f,groundLayer));

        if(canJump)
        {
            jumpCount = 1;
        }
        else
        {
            jumpCount = 0;
        }

        if(inputX != 0)
        { 
            rb.AddForce(transform.right*(inputX * forceMultiplier*Time.deltaTime),ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x/1.1f,rb.velocity.y);
        }

        if(Input.GetKeyDown(jumpButton) && jumpCount>0)
        {
            rb.AddForce(transform.up*(jumpMultiplier - rb.mass*rb.velocity.y),ForceMode2D.Impulse);
            jumpCount--;
            audioSource.PlayOneShot(jumpStartAudio);
        }

        if(rb.velocity.x >3.5f)
        {
            rb.velocity = new Vector2(3.5f,rb.velocity.y);
        }
        else if(rb.velocity.x <-3.5f)
        {
            rb.velocity = new Vector2(-3.5f,rb.velocity.y);
        }

    }
}
