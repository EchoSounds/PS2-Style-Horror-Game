using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRange = 1f;
    public float attackDelay = 1f;
    public int maxHealth = 100;
    public GameObject deathEffect;
    public Animator animator;
    public Transform attackPoint;

    private Transform target;
    private NavMeshAgent agent;
    private int currentHealth;

    private bool isAttacking;
    private float attackTimer;

    private void Start()
    {
        target = FindObjectOfType<PlayerMovement>().gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;

        // Start by waiting for a specified amount of time
        agent.enabled = false;
        Invoke("EnableAgent", 2f);
    }

    private void EnableAgent()
    {
        agent.enabled = true;
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        // If the player is within range, move towards them and attack
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= attackRange)
            {
                // Start attacking
                isAttacking = true;

                if (attackTimer <= 0f)
                {
                    // Attack the player
                    animator.SetTrigger("isAttacking");
                    Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange);
                    foreach (Collider player in hitPlayers)
                    {
                        if (player.CompareTag("Player"))
                        {
                            player.GetComponent<PlayerHealth>().TakeDamage(10);
                        }
                    }

                    // Reset the attack timer
                    attackTimer = attackDelay;
                }
                else
                {
                    // Countdown the attack timer
                    attackTimer -= Time.deltaTime;
                }
            }
            else
            {
                // Stop attacking and start walking
                isAttacking = false;
                //animator.SetBool("isWalking", true);
            }
        }
        else
        {
            // Stop walking and reset the attack timer
            isAttacking = false;
            //animator.SetBool("isWalking", false);
            attackTimer = 0f;
            agent.SetDestination(target.position);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play death effect and destroy the enemy
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}