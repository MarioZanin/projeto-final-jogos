using System.Collections;
using System.Collections.Generic;
// Scripts/EnemyAI.cs
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float stoppingDistance = 2f;
    public int attackDamage = 10;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    private Transform target;
    private Health targetHealth;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target != null)
        {
            targetHealth = target.GetComponent<Health>();
        }
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= nextAttackTime)
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void Attack()
    {
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(attackDamage);
        }
    }
}