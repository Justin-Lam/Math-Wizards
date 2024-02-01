using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitSO : ScriptableObject
{
	public new string name;

	public int maxHealth;
	public int physicalAttack;
	public int critChance;
	public int armor;
	public int spellPower;
	public int spellBreak;
	public int spellDefense;

	public Sprite sprite;
	public Sprite portrait;
}
