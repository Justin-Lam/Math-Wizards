using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Physical Damage Dealing Ability", menuName = "Ability/Physical Damage Dealing Ability")]
public class PhysicalDamageDealingAbilitySO : AbilitySO
{
	[SerializeField][Tooltip("Physical attack * this ratio determines the base physical damage for this ability")] float[] physicalAttackRatios = new float[3];

	public override string GetDescription(Unit user)
	{
		// Calculate base damage
		float basePhysicalDamage = user.PhysicalAttack * physicalAttackRatios[0];		// just using level 1 ability for now

		// Format the description
		string formattedDescription = unformattedDescription.Replace("{basePhysicalDamage}", basePhysicalDamage.ToString());

		// Return the formatted description
		return formattedDescription;
	}

	// Wizard Version
	public override void Activate(Unit target, float mathMultiplier)
	{
		// Calculate base physical damage
		float basePhysicalDamage = user.PhysicalAttack * physicalAttackRatios[0];       // just using level 1 ability for now

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate premitigated physical damage
		float premitigatedPhysicalDamage = basePhysicalDamage * buffDebuffMultiplier * mathMultiplier;

		// Deal premitigatedPhysicalDamage to the target
		target.TakePhysicalDamage(premitigatedPhysicalDamage);
	}

	// Enemy Version
	public override void Activate(Unit target)
	{
		// Calculate base physical damage
		float basePhysicalDamage = user.PhysicalAttack * physicalAttackRatios[0];       // just using level 1 ability for now

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate premitigated physical damage
		float premitigatedPhysicalDamage = basePhysicalDamage * buffDebuffMultiplier;

		// Deal premitigatedPhysicalDamage to the target
		target.TakePhysicalDamage(premitigatedPhysicalDamage);
	}
}
