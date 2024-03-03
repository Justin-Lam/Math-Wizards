using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] FloatingHealthBar floatingHealthBar;
	[SerializeField] Animator animator;
	[SerializeField] GameObject popupTextPrefab;

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
		// Initialize unitSO
		unitSO = inputUnitSO;

		// Initialize abilities' user
		foreach (AbilitySO abilitySO in unitSO.Abilities) { abilitySO.user = this; }

		// Initialize stats
		maxHealth = inputUnitSO.MaxHealth;
		currentHealth = inputUnitSO.MaxHealth;
		physicalAttack = inputUnitSO.PhysicalAttack;
		critChance = inputUnitSO.CritChance;
		armor = inputUnitSO.Armor;
		spellPower = inputUnitSO.SpellPower;
		spellBreak = inputUnitSO.SpellBreak;
		spellDefense = inputUnitSO.SpellDefense;

		// Initialize sprite
		spriteRenderer.sprite = inputUnitSO.Sprite;

		// Initialize floating health bar
		floatingHealthBar.Initialize();
	}

	void CreatePopupText(PopupText.Types type, float num)
	{
		// Create the popup text and get its PopupText script
		PopupText popupText = Instantiate(popupTextPrefab, gameObject.transform.position, gameObject.transform.rotation).GetComponent<PopupText>();

		// Setup the popup text
		popupText.Setup(type, num);
	}


	void TakeDamage (float damage)
	{
		// Take damage
		currentHealth -= damage;

		// Play take damage animation
		animator.SetTrigger("tookDamage");

		// If died, fix health if needed and trigger death animation
		if (currentHealth < 0f)
		{
			currentHealth = 0f;
			animator.SetBool("isAlive", false);
		}

		// Update floating health bar and animator's healthRatio
		StartCoroutine(floatingHealthBar.TakeDamage(currentHealth, maxHealth));
		animator.SetFloat("healthRatio", currentHealth / maxHealth);
	}
	public void TakePhysicalDamage(float damage)
	{
		// Calculate damage ratio (the amount of damage that gets through)
		float damageRatio = 100 / (100 + Armor);

		// Calculate damage taken
		float damageTaken = damage * damageRatio;

		// Take Damage
		TakeDamage(damageTaken);

		// Create popup text
		CreatePopupText(PopupText.Types.PHYSICAL_DAMAGE, damageTaken);
	}
	public void TakeMagicDamage(float damage)
	{
		// Calculate damage ratio (the amount of damage that gets through)
		float damageRatio = 100 / (100 + SpellDefense);

		// Calculate damage taken
		float damageTaken = damage * damageRatio;

		// Take Damage
		TakeDamage(damageTaken);

		// Create popup text
		CreatePopupText(PopupText.Types.MAGIC_DAMAGE, damageTaken);
	}
	public void Heal(float healAmount)
	{
		// Heal
		currentHealth += healAmount;

		// Create popup text
		CreatePopupText(PopupText.Types.HEAL, healAmount);

		// Fix health if needed
		if (currentHealth > maxHealth) { currentHealth = maxHealth; }

		// Update health bar and animator's healthRatio
		StartCoroutine(floatingHealthBar.Heal(currentHealth, maxHealth));
		animator.SetFloat("healthRatio", currentHealth / maxHealth);
	}
	public void Die()
	{
		// Hide the unit
		gameObject.SetActive(false);
	}
}
