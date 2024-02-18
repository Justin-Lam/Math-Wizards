using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Ability", menuName = "Ability/Heal")]
public class HealAbilitySO : AbilitySO
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
	public override void Activate(Unit target, float mathMultiplier)
	{
		Heal(target, healRatio, mathMultiplier);
	}

	// Enemy Version
	public override void Activate(Unit target)
	{
		Heal(target, healRatio);
	}
}
