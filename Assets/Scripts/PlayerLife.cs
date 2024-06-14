using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    public bool alive = true;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void loseLife()
    {
        if (alive)
        {
            alive = false;
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Player>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            GameController.gc.SetLives(-1);

            if (GameController.gc.lives <= 0)
            {
                Invoke("LoadScene", 1f);
            }
            else
            {
                Invoke("LoadGameOver", 1f);
                GameController.gc.lives = 3;
            }
        }
    }
    void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    
    void LoadScene()
    {
        SceneManager.LoadScene("Level 1");
    }
}