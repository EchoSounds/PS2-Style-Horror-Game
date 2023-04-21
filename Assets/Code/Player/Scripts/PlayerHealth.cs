using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthSlider();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthSlider()
    {
        healthSlider.fillAmount = (float)currentHealth / maxHealth;
    }

    private void Die()
    {
        // Do something when the player dies, like restart the level or show a game over screen
    }
}