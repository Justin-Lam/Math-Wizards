using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySO : ScriptableObject
{
	public enum Targets { NONE, WIZARD, ENEMY }


	[HideInInspector] public Unit user;     // the unit that possess this ability


	[SerializeField] new string name;		public string Name => name;
	[SerializeField] Targets targetType;	public Targets TargetType => targetType;
	[SerializeField] Color buttonColor;		public Color ButtonColor => buttonColor;
	[SerializeField] int cooldown;			public int Cooldown => cooldown;


	[SerializeField][TextArea(1, 10)][Tooltip("Description with placeholders (ex. {baseDamage}) instead of variable values")] protected string unformattedDescription;
	public virtual string GetDescription() { return unformattedDescription; }      // returns the description with variables values instead of placeholders


	public virtual void Activate(float mathMultiplier) { }							// wizard ability, untargeted
	public virtual void Activate(Unit target, float mathMultiplier) { }				// wizard ability, targeted
	public virtual void Activate() { }												// enemy ability, targeted
	public virtual void Activate(Unit target) { }                                   // enemy ability, targeted


	protected void DealPhysicalDamage(Unit target, float physicalAttackRatio, float mathMultiplier)
	{
		// Calculate base damage
		float baseDamage = user.PhysicalAttack * physicalAttackRatio;

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate total damage
		float totalDamage = baseDamage * buffDebuffMultiplier * mathMultiplier;

		// Damage the target
		target.TakePhysicalDamage(totalDamage);
	}
	protected void DealPhysicalDamage(Unit target, float physicalAttackRatio)
	{
		// Calculate base damage
		float baseDamage = user.PhysicalAttack * physicalAttackRatio;

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate total damage
		float totalDamage = baseDamage * buffDebuffMultiplier;

		// Damage the target
		target.TakePhysicalDamage(totalDamage);
	}

	protected void DealMagicDamage(Unit target, float spellPowerRatio, float mathMultiplier)
	{
		// Calculate base damage
		float baseDamage = user.SpellPower * spellPowerRatio;

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate total damage
		float totalDamage = baseDamage * buffDebuffMultiplier * mathMultiplier;

		// Damage the target
		target.TakeMagicDamage(totalDamage);
	}
	protected void DealMagicDamage(Unit target, float spellPowerRatio)
	{
		// Calculate base damage
		float baseDamage = user.SpellPower * spellPowerRatio;

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate total damage
		float totalDamage = baseDamage * buffDebuffMultiplier;

		// Damage the target
		target.TakeMagicDamage(totalDamage);
	}

	protected void Heal(Unit target, float healRatio, float mathMultiplier)
	{
		// Calculate base heal amount
		float baseHealAmount = user.SpellPower * healRatio;

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate premitigated heal amount
		float totalHealAmount = baseHealAmount * buffDebuffMultiplier * mathMultiplier;

		// Heal the target
		target.Heal(totalHealAmount);
	}
	protected void Heal(Unit target, float healRatio)
	{
		// Calculate base heal amount
		float baseHealAmount = user.SpellPower * healRatio;

		// Loop through all buffs and debuffs to get buffDebuffMultiplier
		float buffDebuffMultiplier = 1.0f;

		// Calculate premitigated heal amount
		float totalHealAmount = baseHealAmount * buffDebuffMultiplier;

		// Heal the target
		target.Heal(totalHealAmount);
	}
}
