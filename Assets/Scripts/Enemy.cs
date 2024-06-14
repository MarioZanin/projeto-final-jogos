using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            LoadScene();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void LoadScene()
    {
            SceneManager.LoadScene("Level 1");
    }
}