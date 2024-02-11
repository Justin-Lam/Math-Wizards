using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour
{
	[SerializeField] Image portrait;
	[SerializeField] TextMeshProUGUI nameText;
	[SerializeField] Slider healthBar;
	[SerializeField] TextMeshProUGUI healthText;
	[SerializeField] TextMeshProUGUI physicalAttackText;
	[SerializeField] TextMeshProUGUI critChanceText;
	[SerializeField] TextMeshProUGUI armorText;
	[SerializeField] TextMeshProUGUI spellPowerText;
	[SerializeField] TextMeshProUGUI spellBreakText;
	[SerializeField] TextMeshProUGUI spellDefenseText;

	public void UpdateDisplay(Unit unit)
    {
		// Set variables
		portrait.sprite = unit.Portrait;
		nameText.text = unit.Name;
		healthBar.value = unit.CurrentHealth / unit.MaxHealth;
		healthText.text = unit.CurrentHealth + " / " + unit.MaxHealth;
		physicalAttackText.text = unit.PhysicalAttack.ToString();
		critChanceText.text = unit.CritChance.ToString();
		armorText.text = unit.Armor.ToString();
		spellPowerText.text = unit.SpellPower.ToString();
		spellBreakText.text = unit.SpellBreak.ToString();
		spellDefenseText.text = unit.SpellDefense.ToString();
    }
}
