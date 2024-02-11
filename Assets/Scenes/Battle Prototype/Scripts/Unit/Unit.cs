using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] Slider healthBar;
	UnitSO unitSO;

	float maxHealth;			public float MaxHealth => unitSO.maxHealth;
	float currentHealth;		public float CurrentHealth => currentHealth;
	float physicalAttack;		public float PhysicalAttack => physicalAttack;
	float critChance;			public float CritChance => unitSO.critChance;
	float armor;				public float Armor => unitSO.armor;
	float spellPower;			public float SpellPower => unitSO.spellPower;
	float spellBreak;			public float SpellBreak => unitSO.spellBreak;
	float spellDefense;			public float SpellDefense => unitSO.spellDefense;


	public void InitializeUnit()
    {
		// Set stats
		maxHealth = unitSO.maxHealth;
		currentHealth = unitSO.maxHealth;
		physicalAttack = unitSO.physicalAttack;
		critChance = unitSO.critChance;
		armor = unitSO.armor;
		spellPower = unitSO.spellPower;
		spellBreak = unitSO.spellBreak;
		spellDefense = unitSO.spellDefense;

		// Set sprite
		spriteRenderer.sprite = unitSO.sprite;

		// Set health bar
		UpdateHealthBar();
    }

	void UpdateHealthBar()
	{
		healthBar.value = currentHealth / unitSO.maxHealth;
	}

	public void TakePhysicalDamage(float incomingDamage)
	{
		// Calculate damage ratio (the amount of damage that gets through)
		float damageRatio = 100 / (100 + Armor);

		// Calculate damage taken
		float damageTaken = incomingDamage * damageRatio;

		// Take damage
		currentHealth -= damageTaken;

		// Fix health if needed
		if (currentHealth < 0f) { currentHealth = 0f; }

		// Update health bar
		UpdateHealthBar();
	}


	// Other Getters
	public string Name => unitSO.name;

	public Sprite Sprite => unitSO.sprite;
	public Sprite Portrait => unitSO.portrait;

	public AbilitySO[] Abilities => unitSO.abilities;

	// Setters
	public void SetUnitSO(UnitSO input) { unitSO = input; }
}
