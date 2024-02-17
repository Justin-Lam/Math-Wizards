using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySO : ScriptableObject
{
	public enum Targets { NONE, WIZARD, ENEMY }


	[SerializeField] new string name;
	[SerializeField][TextArea(1, 10)][Tooltip("Description with placeholders (ex. {baseDamage}) instead of variable values")] protected string unformattedDescription;
	[SerializeField] Targets targetType;
	[SerializeField] Color buttonColor;
	[SerializeField] int[] cooldowns = new int[3];

	// The following are getter functions that return a field
	// ex. Name => name means GetName() { return name; }
	public string Name => name;
	public virtual string GetDescription(Unit user) { return unformattedDescription; }      // returns the description with variables values instead of placeholders
	public Targets TargetType => targetType;
	public Color ButtonColor => buttonColor;
	public int[] Cooldown => cooldowns;


	protected Unit user;		// the unit that possess this ability
	public void SetUser(Unit unit) { user = unit; }

	
	public virtual void Activate(float mathMultiplier) { }							// wizard ability, untargeted
	public virtual void Activate(Unit target, float mathResultMultiplier) { }       // wizard ability, targeted
	public virtual void Activate() { }												// enemy ability, targeted
	public virtual void Activate(Unit target) { }									// enemy ability, targeted
}
