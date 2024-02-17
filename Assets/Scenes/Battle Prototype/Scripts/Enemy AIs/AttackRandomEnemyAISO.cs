using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Random Enemy AI", menuName = "Enemy AI/Attack Random")]
public class AttackRandomEnemyAISO : EnemyAISO
{
	public override AbilitySO GetAbilitySO()
	{
		// Return this enemy's first ability - it's supposed to be an attacking ability
		return user.Abilities[0];
	}

	public override Unit GetTarget(List<Unit> wizards)
	{
		// Pick a random wizard and return it
		return wizards[Random.Range(0, wizards.Count)];
	}
}
