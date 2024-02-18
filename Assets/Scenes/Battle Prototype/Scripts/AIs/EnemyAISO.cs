using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAISO : ScriptableObject
{
	[HideInInspector] public Unit user;        // the unit that possess this AI

	public virtual AbilitySO GetAbilitySO() { return null;  }
	public virtual Unit GetTarget(List<Unit> wizards) { return null; }
}
