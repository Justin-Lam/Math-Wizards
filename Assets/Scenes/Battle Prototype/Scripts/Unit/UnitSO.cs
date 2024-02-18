using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSO : ScriptableObject
{
	[SerializeField] new string name;					public string Name => name;

	[SerializeField] Sprite sprite;						public Sprite Sprite => sprite;
	[SerializeField] Sprite portrait;					public Sprite Portrait => portrait;

	[SerializeField] int maxHealth;						public int MaxHealth => maxHealth;
	[SerializeField] int physicalAttack;				public int PhysicalAttack => physicalAttack;
	[SerializeField] int critChance;					public int CritChance => critChance;
	[SerializeField] int armor;							public int Armor => armor;
	[SerializeField] int spellPower;					public int SpellPower => spellPower;
	[SerializeField] int spellBreak;					public int SpellBreak => spellBreak;
	[SerializeField] int spellDefense;					public int SpellDefense => spellDefense;

	// public PassiveAbilitySO passiveAbility;
	[SerializeField] AbilitySO[] abilities;				public AbilitySO[] Abilities => abilities;
}
