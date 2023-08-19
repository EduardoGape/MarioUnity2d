using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float forceJump;
    public int maxJumpCount; // Número máximo de pulos
    private Rigidbody2D rb;
    private int jumpCount; // Contador de pulos

    public bool FlipPlayer = true;
    private SpriteRenderer spi;
    private Animator anim;
    public bool ground;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spi = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        maxJumpCount = 2;
        jumpCount = 0;
    }

    void Update()
    {
        MovimentTypeOne();
        FlipX();

    }

    void MovimentTypeOne()
    {

        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            anim.SetInteger("status",1);
        }
        else if (Input.GetKey("d"))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            anim.SetInteger("status",1);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            ground = false;
            anim.SetInteger("status",2);
            rb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            jumpCount++;
        }
        else if(ground)
        {
            anim.SetInteger("status", 0); // Parado quando não estiver se movendo
        }

        
        
    }
    void FlipX(){
        
        if (Input.GetKeyDown("a"))
        {
            spi.flipX = FlipPlayer;
            FlipPlayer = !FlipPlayer;
           
        }
        else if (Input.GetKeyDown("d"))
        {
            spi.flipX = FlipPlayer;
            FlipPlayer = !FlipPlayer;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Resetar o contador de pulos quando colidir com o chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            ground = true;
        }
    }
}