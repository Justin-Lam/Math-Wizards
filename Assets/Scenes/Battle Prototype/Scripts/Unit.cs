using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] FloatingHealthBar healthBarScript;

	protected UnitSO unitSO;
	protected float currentHealth;

	public void InitializeUnit()
    {
		// Set currentHeath
		currentHealth = unitSO.maxHealth;

		// Set sprite
		spriteRenderer.sprite = unitSO.sprite;

        // Set health bar
        healthBarScript.UpdateHealthBar(currentHealth, unitSO.maxHealth);
    }

	public bool IsAlive() { return currentHealth > 0f; }

    public void TakeDamage(int amount)
	{
		// Take damage
		currentHealth -= amount;

        // Update health bar
        healthBarScript.UpdateHealthBar(currentHealth, unitSO.maxHealth);

		// Fix health if needed
		if (currentHealth < 0f)
			currentHealth = 0f;
	}

	public void Heal(int amount)
	{
		// Heal
		currentHealth += amount;

        // Update health bar
        healthBarScript.UpdateHealthBar(currentHealth, unitSO.maxHealth);

        // Fix health if needed
        if (currentHealth > unitSO.maxHealth)
			currentHealth = unitSO.maxHealth;
	}

	public UnitSO GetUnitSO() { return unitSO; }
	public void SetUnitSO(UnitSO input) { unitSO = input; }
	public float GetCurrentHealth() {  return currentHealth; }
}
