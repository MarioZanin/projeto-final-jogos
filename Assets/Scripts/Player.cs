using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D rbPlayer;
    public float speed;
    private SpriteRenderer sr;
    public float jumpForce;
    public bool inFloor = true;
    // Start is called before the first frame update


    private GameController gcPlayer;

    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }
        
    void Start()
    {
        gcPlayer = GameController.gc;
        gcPlayer.Rings = 0;
        gcPlayer.Star = 0;
        gcPlayer.lives = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void MovePlayer()
    {

        float horizontalMoviment = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalMoviment);
        //transform.position += new Vector3(horizontalMoviment * Time.deltaTime * speed,0,0);

        
        rbPlayer.velocity = new Vector2(horizontalMoviment * speed, rbPlayer.velocity.y);

        if(horizontalMoviment > 0)
        {
            playerAnim.SetBool("Walk", true);
            //sr.flipX = false;

            if (transform.localScale.x < 0)
            {
                FlipX();
            }


            
        }
        else if (horizontalMoviment < 0)
        {
            playerAnim.SetBool("Walk", true);
            //sr.flipX = true;
            if (transform.localScale.x > 0)
            {
                FlipX();
            }
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && inFloor)
        {
            playerAnim.SetBool("Jump", true);
            rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            inFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rings")
        {
            Destroy(collision.gameObject);
            gcPlayer.Rings++;
            GameController.gc.RefreshScreen();
        }
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            gcPlayer.Star++;
            gcPlayer.starText.text = gcPlayer.Star.ToString();
        }
        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject);
            gcPlayer.lives++;
            gcPlayer.lifeText.text = gcPlayer.lives.ToString();
        }
    }

    private void FlipX()
    {
        var newScale = transform.localScale;
        newScale.x *= -1;

        transform.localScale = newScale;
    }
}
