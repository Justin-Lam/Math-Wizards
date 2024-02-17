using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] Slider healthBar;
	protected UnitSO unitSO;

	float maxHealth;			public float MaxHealth => maxHealth;
	float currentHealth;		public float CurrentHealth => currentHealth;
	float physicalAttack;		public float PhysicalAttack => physicalAttack;
	float critChance;			public float CritChance => critChance;
	float armor;				public float Armor => armor;
	float spellPower;			public float SpellPower => spellPower;
	float spellBreak;			public float SpellBreak => spellBreak;
	float spellDefense;			public float SpellDefense => spellDefense;


	public virtual void InitializeUnit(UnitSO inputUnitSO, bool isEnemy)
    {
		// Set unitSO
		unitSO = inputUnitSO;

		// Set abilities' user
		foreach (AbilitySO abilitySO in unitSO.Abilities) { abilitySO.SetUser(this); }

		// Set AI if the unit is an enemy
		if (isEnemy) { unitSO.AISO.SetUser(this); }

		// Set stats
		maxHealth = unitSO.MaxHealth;
		currentHealth = unitSO.MaxHealth;
		physicalAttack = unitSO.PhysicalAttack;
		critChance = unitSO.CritChance;
		armor = unitSO.Armor;
		spellPower = unitSO.SpellPower;
		spellBreak = unitSO.SpellBreak;
		spellDefense = unitSO.SpellDefense;

		// Set sprite
		spriteRenderer.sprite = unitSO.Sprite;

		// Set health bar
		UpdateHealthBar();
    }

	void UpdateHealthBar()
	{
		healthBar.value = currentHealth / maxHealth;
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
	public string Name => unitSO.Name;

	public Sprite Sprite => unitSO.Sprite;
	public Sprite Portrait => unitSO.Portrait;

	public AbilitySO[] Abilities => unitSO.Abilities;

	public EnemyAISO AISO => unitSO.AISO;
}
