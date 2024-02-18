using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deal Physical Damage Ability", menuName = "Ability/Deal Physical Damage")]
public class DealPhysicalDamageAbilitySO : AbilitySO
{
	[SerializeField][Tooltip("Physical attack * this ratio determines the physical damage for this ability")] float physicalAttackRatio;

	public override string GetDescription()
	{
		// Calculate base damage
		float physicalDamage = user.PhysicalAttack * physicalAttackRatio;

		// Format the description
		string formattedDescription = unformattedDescription.Replace("{physicalDamage}", Mathf.Ceil(physicalDamage).ToString());

		// Return the formatted description
		return formattedDescription;
	}

	// Wizard Version
	public override void Activate(Unit target, float mathMultiplier)
	{
		DealPhysicalDamage(target, physicalAttackRatio, mathMultiplier);
	}

	// Enemy Version
	public override void Activate(Unit target)
	{
		DealPhysicalDamage(target, physicalAttackRatio);
	}
}
