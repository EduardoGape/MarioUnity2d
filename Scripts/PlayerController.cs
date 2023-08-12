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
    public static float CogumelosCountSize;
    public static int Coin;

    void Start()
    {
        CogumelosCountSize = 0.5f;
        Coin = 0;
        rb = GetComponent<Rigidbody2D>();

        maxJumpCount = 2;
        jumpCount = 0;
    }

    void Update()
    {
        MovimentTypeOne();
        SizePlayer(CogumelosCountSize);
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    void SizePlayer(float size)
    {
       // transform.localScale = new Vector3(size, size, size);
    }

    
    void MovimentTypeOne()
    {
        Jump();

        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
           
        }
        else if (Input.GetKey("d"))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Resetar o contador de pulos quando colidir com o chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Verifica se o personagem está acima do inimigo
            bool jumpedOnEnemy = transform.position.y > collision.transform.position.y;

            if (jumpedOnEnemy)
            {
                rb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
                Destroy(collision.gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("EnemyPlant"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Cano"))
        {
            // Encontre a posição atrás do cano (assumindo que "atrás" é a direção negativa de y)
            Vector3 behindPipePosition = collision.transform.position - new Vector3(0, collision.collider.bounds.size.y, 0);

            // Mova o personagem para lá
            transform.position = behindPipePosition;
        }
    }
}