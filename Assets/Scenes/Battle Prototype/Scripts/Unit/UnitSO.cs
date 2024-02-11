using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitSO : ScriptableObject
{
	public new string name;

	public Sprite sprite;
	public Sprite portrait;

	public int maxHealth;
	public int physicalAttack;
	public int critChance;
	public int armor;
	public int spellPower;
	public int spellBreak;
	public int spellDefense;

	// public PassiveAbilitySO passiveAbility;
	public AbilitySO[] abilities = new AbilitySO[4];
}
