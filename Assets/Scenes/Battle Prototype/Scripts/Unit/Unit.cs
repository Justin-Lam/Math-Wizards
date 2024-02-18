using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] Slider healthBar;

	UnitSO unitSO;		public UnitSO UnitSOVar => unitSO;
	public string Name => unitSO.Name;
	public Sprite Sprite => unitSO.Sprite;
	public Sprite Portrait => unitSO.Portrait;
	public AbilitySO[] Abilities => unitSO.Abilities;

	protected float maxHealth;			public float MaxHealth => maxHealth;
	protected float currentHealth;		public float CurrentHealth => currentHealth;
	protected float physicalAttack;		public float PhysicalAttack => physicalAttack;
	protected float critChance;			public float CritChance => critChance;
	protected float armor;				public float Armor => armor;
	protected float spellPower;			public float SpellPower => spellPower;
	protected float spellBreak;			public float SpellBreak => spellBreak;
	protected float spellDefense;		public float SpellDefense => spellDefense;


	protected void InitializeUnit(UnitSO inputUnitSO)
	{
		// Set unitSO
		unitSO = inputUnitSO;

		// Set abilities' user
		foreach (AbilitySO abilitySO in unitSO.Abilities) { abilitySO.user = this; }

		// Set stats
		maxHealth = inputUnitSO.MaxHealth;
		currentHealth = inputUnitSO.MaxHealth;
		physicalAttack = inputUnitSO.PhysicalAttack;
		critChance = inputUnitSO.CritChance;
		armor = inputUnitSO.Armor;
		spellPower = inputUnitSO.SpellPower;
		spellBreak = inputUnitSO.SpellBreak;
		spellDefense = inputUnitSO.SpellDefense;

		// Set sprite
		spriteRenderer.sprite = inputUnitSO.Sprite;

		// Set health bar
		UpdateHealthBar();
	}

	void UpdateHealthBar()
	{
		healthBar.value = currentHealth / maxHealth;
	}

	public void TakePhysicalDamage(float damage)
	{
		// Calculate damage ratio (the amount of damage that gets through)
		float damageRatio = 100 / (100 + Armor);

		// Calculate damage taken
		float damageTaken = damage * damageRatio;

		// Take damage
		currentHealth -= damageTaken;

		// Fix health if needed
		if (currentHealth < 0f) { currentHealth = 0f; }

		// Update health bar
		UpdateHealthBar();
	}

	public void Heal(float healAmount)
	{
		// Heal
		currentHealth += healAmount;

		// Fix health if needed
		if (currentHealth > maxHealth) { currentHealth = maxHealth; }

		// Update health bar
		UpdateHealthBar();
	}
}
