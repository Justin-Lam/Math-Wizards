using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Group Ability", menuName = "Ability/Heal Group")]
public class HealGroupAbilitySO : AbilitySO
{
	[SerializeField][Tooltip("Spell power * this ratio determines the healing amount for this ability")] float healRatio;

	public override string GetDescription()
	{
		// Calculate base damage
		float healAmount = user.SpellPower * healRatio;

		// Format the description
		string formattedDescription = unformattedDescription.Replace("{healAmount}", Mathf.Ceil(healAmount).ToString());

		// Return the formatted description
		return formattedDescription;
	}

	// Wizard Version
	public override void Activate(float mathMultiplier)
	{
		// Get BattleManager
		BattleManager battleManager = FindObjectOfType<BattleManager>();

		// Heal every wizard
		foreach (Wizard wizard in battleManager.aliveWizards) { Heal(wizard, healRatio, mathMultiplier); }
	}

	// Enemy Version
	public override void Activate()
	{
		// Get BattleManager
		BattleManager battleManager = FindObjectOfType<BattleManager>();

		// Heal every enemy
		foreach (Enemy enemy in battleManager.aliveEnemies) { Heal(enemy, healRatio); }
	}
}
