using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deal Hybrid Damage Ability", menuName = "Ability/Deal Hybrid Damage")]
public class DealHybridDamageAbilitySO : AbilitySO
{
	[SerializeField][Tooltip("Physical attack * this ratio determines the physical damage for this ability")] float physicalAttackRatio;
	[SerializeField][Tooltip("Spell power * this ratio determines the magic damage for this ability")] float spellPowerRatio;

	public override string GetDescription()
	{
		// Calculate physical damage and magic damage
		float physicalDamage = user.PhysicalAttack * physicalAttackRatio;
		float magicDamage = user.SpellPower * spellPowerRatio;

		// Format the description
		string formattedDescription = unformattedDescription.Replace("{physicalDamage}", Mathf.Ceil(physicalDamage).ToString());
		formattedDescription = formattedDescription.Replace("{magicDamage}", Mathf.Ceil(magicDamage).ToString());

		// Return the formatted description
		return formattedDescription;
	}

	// Wizard Version
	public override void Activate(Unit target, float mathMultiplier)
	{
		DealPhysicalDamage(target, physicalAttackRatio, mathMultiplier);
		DealMagicDamage(target, spellPowerRatio, mathMultiplier);
	}

	// Enemy Version
	public override void Activate(Unit target)
	{
		DealPhysicalDamage(target, physicalAttackRatio);
		DealMagicDamage(target, spellPowerRatio);
	}
}
