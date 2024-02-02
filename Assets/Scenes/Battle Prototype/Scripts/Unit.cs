using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] FloatingHealthBar healthBarScript;

	UnitSO unitSO;
	float currentHeath;

	public void InitializeUnit()
    {
		// Set currentHeath
		currentHeath = unitSO.maxHealth;

		// Set sprite
		spriteRenderer.sprite = unitSO.sprite;

        // Set health bar
        healthBarScript.UpdateHealthBar(currentHeath, unitSO.maxHealth);
    }

	public bool IsAlive() { return currentHeath > 0f; }

    public void TakeDamage(int amount)
	{
		// Take damage
		currentHeath -= amount;

        // Update health bar
        healthBarScript.UpdateHealthBar(currentHeath, unitSO.maxHealth);

		// Fix health if needed
		if (currentHeath < 0f)
			currentHeath = 0f;
	}

	public void Heal(int amount)
	{
		// Heal
		currentHeath += amount;

        // Update health bar
        healthBarScript.UpdateHealthBar(currentHeath, unitSO.maxHealth);

        // Fix health if needed
        if (currentHeath > unitSO.maxHealth)
			currentHeath = unitSO.maxHealth;
	}

	public UnitSO GetUnitSO() { return unitSO; }
	public void SetUnitSO(UnitSO input) { unitSO = input; }
	public float GetCurrentHealth() {  return currentHeath; }
}
